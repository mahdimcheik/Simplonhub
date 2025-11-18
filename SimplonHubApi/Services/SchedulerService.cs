using System.Collections;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using SimplonHubApi.Contexts;
using SimplonHubApi.Models;
using SimplonHubApi.Templates;
using SimplonHubApi.Utilities;

namespace SimplonHubApi.Services
{
    public class SchedulerService
    {
        private readonly MainContext _context;
        private readonly IServiceProvider _serviceProvider;
        private readonly MailService mailService;

        public SchedulerService(
            MainContext context,
            IServiceProvider serviceProvider,
            MailService mailService
        )
        {
            _context = context;
            _serviceProvider = serviceProvider;
            this.mailService = mailService;
        }

        public async Task CleanOrders()
        {
            // basic method
        }

        public void SchedulerSingleOrderCleaning(string orderId)
        {
            // j'annule l'ancien job avant de planifier un nouveau
            //CancelScheuledJob(orderId);
            //int delay = EnvironmentVariables.HANGFIRE_ORDER_CLEANING_DELAY;

            //var jobId = BackgroundJob.Schedule(() => TrackOrder(orderId), TimeSpan.FromMinutes(delay));
            //ScheduleJobOrderTable.Add(orderId, jobId);
        }

        public async Task RemoveOldSlots()
        {
            var lastWeek = DateTimeOffset.UtcNow.Date.AddDays(-7);
            var oldBookings = await _context
                .Slots.Include(s => s.Booking)
                .Where(s =>
                    s.DateTo < DateTimeOffset.UtcNow && s.DateTo > lastWeek && s.Booking == null
                    || s.Booking.StatusId == HardCode.BOOKING_PENDING
                )
                .ToListAsync();

            _context.Slots.RemoveRange(oldBookings);
            await _context.SaveChangesAsync();
        }

        public async Task SendReminderMails()
        {
            var bookings = await _context
                .Bookings.Include(b => b.Slot)
                .ThenInclude(s => s.Teacher)
                .Include(b => b.Slot)
                .ThenInclude(s => s.Type)
                .Include(b => b.Student)
                .Where(b =>
                    b.Slot.Booking != null
                    && b.Slot.DateFrom > DateTimeOffset.UtcNow
                    && b.Slot.DateFrom < DateTimeOffset.UtcNow.AddHours(48)
                )
                .ToListAsync();

            var reminders = bookings.Select(b =>
            {
                b.Slot.Booking = b;
                return new ReminderModel(b.Slot.Teacher, b.Student, b.Slot, "site url");
            });

            foreach (var reminder in reminders)
            {
                reminder.forTeacher = true;
                await mailService.SendReminder(reminder);

                await Task.Delay(200);

                reminder.forTeacher = false;
                await mailService.SendReminder(reminder);
                await Task.Delay(200);
            }
        }
    }
}

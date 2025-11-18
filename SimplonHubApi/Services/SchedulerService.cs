using System.Collections;
using System.Threading.Tasks;
using Hangfire;
using MainBoilerPlate.Contexts;
using MainBoilerPlate.Utilities;
using Microsoft.EntityFrameworkCore;
using SimplonHubApi.Models;

namespace SimplonHubApi.Services
{
    public class SchedulerService
    {
        private readonly MainContext _context;
        private readonly IServiceProvider _serviceProvider;


        public SchedulerService(MainContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
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
                .Where(s => s.DateTo < DateTimeOffset.UtcNow && s.DateTo > lastWeek && s.Booking == null || s.Booking.StatusId == HardCode.BOOKING_PENDING )
                .ToListAsync();

            _context.Slots.RemoveRange(oldBookings);
            await _context.SaveChangesAsync();
        }
    }
}

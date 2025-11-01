using MainBoilerPlate.Models.Generics;
using MainBoilerPlate.Utilities;
using SimplonHubApi.Models;
using System.Diagnostics.CodeAnalysis;

namespace MainBoilerPlate.Models
{
    public class Booking : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid SlotId { get; set; }
        public Slot Slot { get; set; }

        public StatusBooking Status { get; set; }
        public Guid StatusId { get; set; } = HardCode.BOOKING_PENDING;

        //public Guid OrderId { get; set; }
        //public Order Order { get; set; }

        public Guid StudentId { get; set; }
        public UserApp Student { get; set; }
        public Booking()
        {
            
        }
        [SetsRequiredMembers]
        public Booking(BookingCreateDTO bookingCreate)
        {
            Title = bookingCreate.Title;
            Description = bookingCreate.Description;
            SlotId = bookingCreate.SlotId;
            StudentId = bookingCreate.StudentId;
        }
    }
}

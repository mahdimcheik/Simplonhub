using MainBoilerPlate.Models;

namespace SimplonHubApi.Models
{
    public class BookingDetailsDTO(Booking booking)
    {
        public Guid Id => booking.Id;
        public string Title => booking.Title;
        public string Description => booking.Description;
        public UserResponseDTO? Student => booking.Student is not null ? new UserResponseDTO(booking.Student, null) : null;
    }

    public class BookingCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public UserResponseDTO? Student { get; set; }
        public Guid SlotId { get; set; }
        public Guid StudentId { get; set; }


    }
}

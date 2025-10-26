using MainBoilerPlate.Models;

namespace SimplonHubApi.Models
{
    public class BookingDetailsDTO(Booking booking)
    {
        public string Title => booking.Title;
        public string Description => booking.Description;
        public UserResponseDTO? Student => booking.Student is not null ? new UserResponseDTO(booking.Student, null) : null;
    }
}

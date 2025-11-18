using SimplonHubApi.Models;
using System.ComponentModel.DataAnnotations;

namespace SimplonHubApi.Models
{
    public class BookingDetailsDTO(Booking booking)
    {
        public Guid Id => booking.Id;
        public string Title => booking.Title;
        public string Description => booking.Description;
        public StatusBookingDTO? Status =>
            booking.Status is not null ? new StatusBookingDTO(booking.Status) : null;
        public UserResponseDTO? Student =>
            booking.Student is not null ? new UserResponseDTO(booking.Student, null) : null;
        public SlotDetailsDTO? Slot => booking.Slot is not null ? new SlotDetailsDTO(booking.Slot) : null;
    }

    public class BookingCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public UserResponseDTO? Student { get; set; }
        public Guid SlotId { get; set; }
        public Guid StudentId { get; set; }
    }

    public class BookingUpdateDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public void UpdateModel(Booking booking)
        {
            booking.Title = Title;
            booking.Description = Description;
        }
    }
}

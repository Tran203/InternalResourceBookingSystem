using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InternalResourceBookingSystem.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "Location cannot exceed 100 characters")]
        public string Location { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be a positive number")]
        public int Capacity { get; set; }

        [DisplayName("Available")]
        public bool IsAvailable { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}

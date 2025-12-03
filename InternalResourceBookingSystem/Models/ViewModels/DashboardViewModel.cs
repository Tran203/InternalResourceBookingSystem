namespace InternalResourceBookingSystem.Models.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Booking> Bookings { get; set; }
        public DateTime SelectedDate { get; set; }
        public IEnumerable<Booking> SelectedDayBookings { get; set; }
        public DateTime CurrentMonth { get; set; }
    }
}

using System.Diagnostics;
using InternalResourceBookingSystem.Data;
using InternalResourceBookingSystem.Models;
using InternalResourceBookingSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternalResourceBookingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(DateTime? selectedDate, int? year, int? month)
        {
            // Validate year and month, set to current date if invalid
            int validYear = year.HasValue && year.Value >= 2000 && year.Value <= 2100 ? year.Value : DateTime.Today.Year;
            int validMonth = month.HasValue && month.Value >= 1 && month.Value <= 12 ? month.Value : DateTime.Today.Month;
            var currentMonth = new DateTime(validYear, validMonth, 1);
            var startOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);

            // set selectedDate to first day of the displayed month if not provided or to todays date
            var selected = selectedDate?.Date
                ?? (validYear == DateTime.Today.Year && validMonth == DateTime.Today.Month
                    ? DateTime.Today
                    : startOfMonth);

            // Validate selectedDate is within a reasonable range
            if (selected < new DateTime(2000, 1, 1) || selected > new DateTime(2100, 12, 31))
            {
                selected = startOfMonth;
            }

            // Get active bookings for the month
            var bookings = await _context.Bookings
                .Include(b => b.Resource)
                .Where(b => b.EndTime >= DateTime.Now && b.StartTime >= startOfMonth && b.StartTime <= endOfMonth)
                .ToListAsync();

            // Get bookings for the selected day
            var selectedDayBookings = bookings
                .Where(b => b.StartTime.Date == selected.Date)
                .OrderBy(b => b.StartTime)
                .ToList();

            // Prepare view model
            var viewModel = new DashboardViewModel
            {
                Bookings = bookings,
                SelectedDate = selected,
                SelectedDayBookings = selectedDayBookings,
                CurrentMonth = startOfMonth
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

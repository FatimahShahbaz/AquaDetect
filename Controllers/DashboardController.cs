using AquaDetect.Data;
using AquaDetect.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AquaDetect.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Admin()
        {
            var reports = await _context.Reports
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            var viewModel = new AdminDashboardViewModel
            {
                OpenReports = reports.Count(r => r.Status != "Resolved"),

                CriticalReports = reports.Count(r => r.Severity == "Critical"),

                DuplicatesToReview = reports.Count(r => r.DuplicateCount > 0),

                ResolvedReports = reports.Count(r => r.Status == "Resolved"),

                Reports = reports
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Reporter")]
        public async Task<IActionResult> Reporter()
        {
            var userId = _userManager.GetUserId(User);
            var reports = await _context.Reports.Where(r => r.UserId == userId).OrderByDescending(r => r.CreatedAt).ToListAsync();
            var viewModel = new ReporterDashboardViewModel
            {
                TotalReports = reports.Count,

                PendingReports = reports.Count(r => r.Status == "Pending"),

                InProgressReports = reports.Count(r => r.Status == "In Progress"),

                ResolvedReports = reports.Count(r => r.Status == "Resolved"),

                Reports = reports
            };

            return View(viewModel);
        }
    }
}

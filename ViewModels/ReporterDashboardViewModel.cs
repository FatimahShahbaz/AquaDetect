using AquaDetect.Models;

namespace AquaDetect.ViewModels
{
    public class ReporterDashboardViewModel
    {
        public int TotalReports { get; set; }

        public int PendingReports { get; set; }

        public int InProgressReports { get; set; }

        public int ResolvedReports { get; set; }

        public List<Report> Reports { get; set; } = new List<Report>();
    }
}


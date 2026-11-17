using AquaDetect.Models;
namespace AquaDetect.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int OpenReports { get; set; }

        public int CriticalReports { get; set; }

        public int DuplicatesToReview { get; set; }

        public int ResolvedReports { get; set; }

        public List<Report> Reports { get; set; } = new List<Report>();
    }
}

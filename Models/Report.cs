using System.ComponentModel.DataAnnotations;

namespace AquaDetect.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        public string ReportCode { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public string Severity { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        public int DuplicateCount { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string UserId { get; set; } = string.Empty;
    }
}

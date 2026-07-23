using System.ComponentModel.DataAnnotations;

namespace ISMSPortal.ViewModels.Awareness
{
    public class AwarenessSessionCreateViewModel
    {
        [Required]
        public string SessionTitle { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public DateTime SessionDate { get; set; } = DateTime.Today;

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string Audience { get; set; } = string.Empty;

        public string? Trainer { get; set; }

        public string? Venue { get; set; }

        public bool IsPublished { get; set; } = true;

        public int DisplayOrder { get; set; } = 1;
    }
}
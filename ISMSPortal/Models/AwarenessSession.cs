using System.ComponentModel.DataAnnotations;

namespace ISMSPortal.Models
{
    public class AwarenessSession : BaseEntity
    {
        [Key]
        public int AwarenessSessionId { get; set; }

        [Required]
        [StringLength(200)]
        public string SessionTitle { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime SessionDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        [StringLength(100)]
        public string Audience { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Trainer { get; set; }

        [StringLength(150)]
        public string? Venue { get; set; }

        public bool IsPublished { get; set; }

        public int DisplayOrder { get; set; }
    }
}
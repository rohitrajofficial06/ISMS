using System.ComponentModel.DataAnnotations;

namespace ISMSPortal.Models
{
    public class Announcement : BaseEntity
    {
        [Key]
        public int AnnouncementId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime PublishDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [StringLength(500)]
        public string? AttachmentPath { get; set; }

        public bool IsPinned { get; set; }

        public bool IsPublished { get; set; } = true;

        public int DisplayOrder { get; set; } = 0;
    }
}
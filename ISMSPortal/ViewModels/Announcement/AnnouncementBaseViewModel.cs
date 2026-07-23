using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ISMSPortal.ViewModels.Announcement
{
    public class AnnouncementBaseViewModel
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Today;

        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }

        public IFormFile? Attachment { get; set; }

        public string? AttachmentPath { get; set; }

        public bool IsPinned { get; set; }

        public bool IsPublished { get; set; } = true;

        public int DisplayOrder { get; set; } = 1;
    }
}
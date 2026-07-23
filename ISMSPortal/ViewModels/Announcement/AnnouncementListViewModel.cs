namespace ISMSPortal.ViewModels.Announcement
{
    public class AnnouncementListViewModel
    {
        public int AnnouncementId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime PublishDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string? AttachmentPath { get; set; }

        public bool IsPinned { get; set; }

        public bool IsPublished { get; set; }

        public bool IsActive { get; set; }
    }
}
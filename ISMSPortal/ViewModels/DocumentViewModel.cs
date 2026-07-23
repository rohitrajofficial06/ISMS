namespace ISMSPortal.ViewModels
{
    public class DocumentViewModel
    {
        public int DocumentId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Version { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string? AttachmentFileName { get; set; }

        public string? AttachmentPath { get; set; }

        public string? AttachmentContentType { get; set; }

        public bool IsActive { get; set; }
    }
}
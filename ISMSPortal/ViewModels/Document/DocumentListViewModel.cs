namespace ISMSPortal.ViewModels.Document
{
    public class DocumentListViewModel
    {
        public int DocumentId { get; set; }

        public string DocumentNumber { get; set; } = string.Empty;

        public string DocumentName { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string? Department { get; set; }

        public string? Owner { get; set; }

        public string Version { get; set; } = string.Empty;

        public DateTime EffectiveDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public bool IsPublished { get; set; }

        public string? AttachmentPath { get; set; }
    }
}
namespace ISMSPortal.ViewModels.Document
{
    public class DocumentWidgetViewModel
    {
        public int DocumentId { get; set; }

        public string DocumentNumber { get; set; } = string.Empty;

        public string DocumentName { get; set; } = string.Empty;

        public string Version { get; set; } = string.Empty;

        public string? AttachmentPath { get; set; }

        public DateTime EffectiveDate { get; set; }
    }
}
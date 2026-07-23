namespace ISMSPortal.ViewModels.Dashboard
{
    public class RecentDocumentWidgetViewModel
    {
        public int DocumentId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public DateTime EffectiveDate { get; set; }
    }
}
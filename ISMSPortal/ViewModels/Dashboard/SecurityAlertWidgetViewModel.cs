namespace ISMSPortal.ViewModels.Dashboard
{
    public class SecurityAlertWidgetViewModel
    {
        public int AlertId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? AlertType { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
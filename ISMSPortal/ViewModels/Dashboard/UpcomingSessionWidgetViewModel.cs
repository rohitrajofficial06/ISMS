namespace ISMSPortal.ViewModels.Dashboard
{
    public class UpcomingSessionWidgetViewModel
    {
        public string Title { get; set; } = string.Empty;

        public DateTime SessionDate { get; set; }

        public string Time { get; set; } = string.Empty;

        public string Mode { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;
    }
}
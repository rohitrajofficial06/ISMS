namespace ISMSPortal.ViewModels.Awareness
{
    public class AwarenessSessionWidgetViewModel
    {
        public int AwarenessSessionId { get; set; }

        public string SessionTitle { get; set; } = string.Empty;

        public DateTime SessionDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string Audience { get; set; } = string.Empty;
    }
}
namespace ISMSPortal.ViewModels.Awareness
{
    public class AwarenessSessionListViewModel
    {
        public int AwarenessSessionId { get; set; }

        public string SessionTitle { get; set; } = string.Empty;

        public DateTime SessionDate { get; set; }

        public string Audience { get; set; } = string.Empty;

        public bool IsPublished { get; set; }
    }
}
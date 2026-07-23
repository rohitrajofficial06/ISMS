namespace ISMSPortal.ViewModels.SecurityAlert
{
    public class SecurityAlertListViewModel
    {
        public int SecurityAlertId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Severity { get; set; } = string.Empty;

        public DateTime PublishDate { get; set; }

        public bool IsPublished { get; set; }
    }
}
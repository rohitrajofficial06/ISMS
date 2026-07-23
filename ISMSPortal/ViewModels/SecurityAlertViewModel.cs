namespace ISMSPortal.ViewModels
{
    public class SecurityAlertViewModel
    {
        public int AlertId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? AlertType { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsActive { get; set; }
    }
}
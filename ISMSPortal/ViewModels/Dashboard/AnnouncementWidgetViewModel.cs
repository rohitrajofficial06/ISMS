namespace ISMSPortal.ViewModels.Dashboard
{
    public class AnnouncementWidgetViewModel
    {
        public int AnnouncementId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsPinned { get; set; }
    }
}
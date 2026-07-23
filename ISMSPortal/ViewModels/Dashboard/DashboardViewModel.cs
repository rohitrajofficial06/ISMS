namespace ISMSPortal.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        // Latest Announcements
        public List<AnnouncementWidgetViewModel> Announcements { get; set; } = new();

        // Latest Policies
        public List<LatestPolicyWidgetViewModel> LatestPolicies { get; set; } = new();

        // Security Alerts
        public List<SecurityAlertWidgetViewModel> SecurityAlerts { get; set; } = new();

        // Recent Documents
        public List<RecentDocumentWidgetViewModel> RecentDocuments { get; set; } = new();

        public HeroBannerWidgetViewModel HeroBanner { get; set; } = new();

        public List<QuickActionWidgetViewModel> QuickActions { get; set; } = new();

        public AwarenessProgressWidgetViewModel AwarenessProgress { get; set; } = new();
        public List<UpcomingSessionWidgetViewModel> UpcomingSessions { get; set; } = new();

    }
}
using ISMSPortal.Repositories.Interfaces;
using ISMSPortal.Services.Interfaces;
using ISMSPortal.ViewModels.Dashboard;

namespace ISMSPortal.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<DashboardViewModel> GetDashboardAsync()
        {
            return new DashboardViewModel
            {
                HeroBanner = GetHeroBanner(),

                QuickActions = GetQuickActions(),

                AwarenessProgress = GetAwarenessProgress(),

                 UpcomingSessions = GetUpcomingSessions(),

                Announcements = await _dashboardRepository.GetLatestAnnouncementsAsync(),

                LatestPolicies = await _dashboardRepository.GetLatestPoliciesAsync(),

                SecurityAlerts = await _dashboardRepository.GetLatestAlertsAsync(),

                RecentDocuments = await _dashboardRepository.GetRecentDocumentsAsync()
            };
        }

        private HeroBannerWidgetViewModel GetHeroBanner()
        {
            return new HeroBannerWidgetViewModel
            {
                Title = "Information Security Management System",
                Subtitle = "ISO/IEC 27001:2022 Certified",
                Description = "Committed to protecting information,<br/>ensuring business continuity and<br/>building trust every day.",
                BackgroundImage = "/images/banner/banner.png"
            };
        }

        private List<QuickActionWidgetViewModel> GetQuickActions()
        {
            return new List<QuickActionWidgetViewModel>
    {
        new()
        {
            Title = "Report Incident",
            Description = "Report security incidents",
            Url = "/IncidentManagement",
            OpenInNewTab = true
        },

        new()
        {
            Title = "Report Phishing Email",
            Description = "Report suspicious emails",
            Url = "/IncidentManagement/Phishing",
            OpenInNewTab = true
        },

        new()
        {
            Title = "Policy Repository",
            Description = "Access all ISMS policies",
            Url = "https://ykgwoffice.sharepoint.com/sites/YIL-ITSIN/ISMSPOLICIES/Forms/AllItems.aspx",
            OpenInNewTab = true

        },

        new()
        {
            Title = "Training & Awareness",
            Description = "View training materials",
            Url = "https://ykgwoffice.sharepoint.com/sites/YIL-ITSIN/ISMSTraining/Forms/AllItems.aspx",
            OpenInNewTab = true
        }
        
        //,

        //new()
        //{
        //    Title = "Session Recordings",
        //    Description = "Watch recorded sessions",
        //    Url = "/AwarenessSession/Recordings",
        //    OpenInNewTab = true
        //},

        //new()
        //{
        //    Title = "Posters & Presentations",
        //    Description = "View awareness content",
        //    Url = "/Document",
        //    OpenInNewTab = true
        //}
    };
        }

        private AwarenessProgressWidgetViewModel GetAwarenessProgress()
        {
            return new AwarenessProgressWidgetViewModel
            {
                Title = "Security Awareness Progress",
                Completed = 185,
                Total = 200,
                ProgressColor = "success"
            };
        }

        private List<UpcomingSessionWidgetViewModel> GetUpcomingSessions()
        {
            return new List<UpcomingSessionWidgetViewModel>
    {
        new()
        {
            Title = "ISO 27001 Awareness",
            SessionDate = DateTime.Today.AddDays(3),
            Time = "10:00 AM",
            Mode = "Online",
            Location = "Microsoft Teams"
        },

        new()
        {
            Title = "Cyber Security Workshop",
            SessionDate = DateTime.Today.AddDays(7),
            Time = "02:00 PM",
            Mode = "Offline",
            Location = "Conference Room A"
        },

        new()
        {
            Title = "Phishing Awareness",
            SessionDate = DateTime.Today.AddDays(10),
            Time = "11:00 AM",
            Mode = "Online",
            Location = "Zoom"
        }
    };
        }
    }
}
using ISMSPortal.ViewModels.Dashboard;

namespace ISMSPortal.Repositories.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<AnnouncementWidgetViewModel>> GetLatestAnnouncementsAsync(int count = 5);

        Task<List<LatestPolicyWidgetViewModel>> GetLatestPoliciesAsync(int count = 5);

        Task<List<SecurityAlertWidgetViewModel>> GetLatestAlertsAsync(int count = 5);

        Task<List<RecentDocumentWidgetViewModel>> GetRecentDocumentsAsync(int count = 5);
    }
}
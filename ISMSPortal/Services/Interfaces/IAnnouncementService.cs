using ISMSPortal.ViewModels.Announcement;
using ISMSPortal.ViewModels.Dashboard;

namespace ISMSPortal.Services.Interfaces
{
    public interface IAnnouncementService
    {
        Task<List<AnnouncementListViewModel>> GetAllAsync(string? searchText = null);

        Task<AnnouncementEditViewModel?> GetByIdAsync(int id);

        Task CreateAsync(AnnouncementCreateViewModel model);

        Task UpdateAsync(AnnouncementEditViewModel model);

        Task DeleteAsync(int id);

        Task<List<AnnouncementWidgetViewModel>> GetDashboardAnnouncementsAsync(int count = 5);
    }
}
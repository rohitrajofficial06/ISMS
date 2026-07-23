using ISMSPortal.ViewModels.Awareness;

namespace ISMSPortal.Services.Interfaces
{
    public interface IAwarenessSessionService
    {
        Task<List<AwarenessSessionListViewModel>> GetAllAsync(string? searchText);

        Task<AwarenessSessionEditViewModel?> GetByIdAsync(int id);

        Task CreateAsync(AwarenessSessionCreateViewModel model);

        Task UpdateAsync(AwarenessSessionEditViewModel model);

        Task DeleteAsync(int id);

        Task<List<AwarenessSessionWidgetViewModel>> GetUpcomingSessionsAsync(int count = 5);
    }
}
using ISMSPortal.ViewModels.SecurityAlert;

namespace ISMSPortal.Services.Interfaces
{
    public interface ISecurityAlertService
    {
        Task<List<SecurityAlertListViewModel>> GetAllAsync(string? searchText);

        Task<SecurityAlertEditViewModel?> GetByIdAsync(int id);

        Task CreateAsync(SecurityAlertCreateViewModel model);

        Task UpdateAsync(SecurityAlertEditViewModel model);

        Task DeleteAsync(int id);

        Task<List<SecurityAlertWidgetViewModel>> GetDashboardAlertsAsync(int count = 5);
    }
}
using ISMSPortal.ViewModels.Policy;

namespace ISMSPortal.Services.Interfaces
{
    public interface IPolicyService
    {
        Task<List<PolicyListViewModel>> GetAllAsync(string? searchText = null);

        Task<PolicyEditViewModel?> GetByIdAsync(int id);

        Task CreateAsync(PolicyCreateViewModel model);

        Task UpdateAsync(PolicyEditViewModel model);

        Task DeleteAsync(int id);
    }
}
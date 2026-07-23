using ISMSPortal.Models;

namespace ISMSPortal.Repositories.Interfaces
{
    public interface IPolicyRepository
    {
        Task<List<Policy>> GetAllAsync();

        Task<List<Policy>> SearchAsync(string? searchText);

        Task<Policy?> GetByIdAsync(int id);

        Task<List<Policy>> GetLatestAsync(int count);

        Task AddAsync(Policy policy);

        Task UpdateAsync(Policy policy);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}
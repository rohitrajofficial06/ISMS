using ISMSPortal.Models;

namespace ISMSPortal.Repositories.Interfaces
{
    public interface ISecurityAlertRepository
    {
        Task<List<SecurityAlert>> GetAllAsync();

        Task<List<SecurityAlert>> SearchAsync(string? searchText);

        Task<SecurityAlert?> GetByIdAsync(int id);

        Task<List<SecurityAlert>> GetLatestAsync(int count);

        Task AddAsync(SecurityAlert entity);

        Task UpdateAsync(SecurityAlert entity);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}
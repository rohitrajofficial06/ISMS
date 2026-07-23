using ISMSPortal.Models;

namespace ISMSPortal.Repositories.Interfaces
{
    public interface IAwarenessSessionRepository
    {
        Task<List<AwarenessSession>> GetAllAsync();

        Task<List<AwarenessSession>> SearchAsync(string? searchText);

        Task<AwarenessSession?> GetByIdAsync(int id);

        Task<List<AwarenessSession>> GetUpcomingSessionsAsync(int count);

        Task AddAsync(AwarenessSession entity);

        Task UpdateAsync(AwarenessSession entity);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}
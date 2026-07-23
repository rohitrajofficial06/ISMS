using ISMSPortal.Models;

namespace ISMSPortal.Repositories.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<List<Announcement>> GetAllAsync();

        Task<List<Announcement>> SearchAsync(string? searchText);

        Task<Announcement?> GetByIdAsync(int id);

        Task<List<Announcement>> GetLatestAsync(int count);

        Task AddAsync(Announcement announcement);

        Task UpdateAsync(Announcement announcement);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}
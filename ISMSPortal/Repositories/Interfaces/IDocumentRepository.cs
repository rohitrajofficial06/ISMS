using ISMSPortal.Models;

namespace ISMSPortal.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        Task<List<Document>> GetAllAsync();

        Task<List<Document>> SearchAsync(string? searchText);

        Task<Document?> GetByIdAsync(int id);

        Task<List<Document>> GetLatestAsync(int count);

        Task AddAsync(Document document);

        Task UpdateAsync(Document document);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}
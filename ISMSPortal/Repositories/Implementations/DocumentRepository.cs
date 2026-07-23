using Microsoft.EntityFrameworkCore;
using ISMSPortal.Data;
using ISMSPortal.Models;
using ISMSPortal.Repositories.Interfaces;

namespace ISMSPortal.Repositories.Implementations
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Document>> GetAllAsync()
        {
            return await _context.Documents
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .ThenByDescending(x => x.EffectiveDate)
                .ToListAsync();
        }

        public async Task<List<Document>> SearchAsync(string? searchText)
        {
            return await _context.Documents
                .Where(x => x.IsActive &&
                       (string.IsNullOrEmpty(searchText) ||
                        x.DocumentNumber.Contains(searchText) ||
                        x.DocumentName.Contains(searchText) ||
                        x.Category.Contains(searchText)))
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
        }

        public async Task<Document?> GetByIdAsync(int id)
        {
            return await _context.Documents
                .FirstOrDefaultAsync(x => x.DocumentId == id && x.IsActive);
        }

        public async Task<List<Document>> GetLatestAsync(int count)
        {
            return await _context.Documents
                .Where(x => x.IsActive && x.IsPublished)
                .OrderByDescending(x => x.CreatedDate)
                .Take(count)
                .ToListAsync();
        }

        public async Task AddAsync(Document document)
        {
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Document document)
        {
            _context.Documents.Update(document);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Documents.FindAsync(id);

            if (entity == null)
                return;

            entity.IsActive = false;
            entity.ModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Documents
                .AnyAsync(x => x.DocumentId == id && x.IsActive);
        }
    }
}
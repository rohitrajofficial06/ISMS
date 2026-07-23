using Microsoft.EntityFrameworkCore;
using ISMSPortal.Data;
using ISMSPortal.Models;
using ISMSPortal.Repositories.Interfaces;

namespace ISMSPortal.Repositories.Implementations
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Announcement>> GetAllAsync()
        {
            return await _context.Announcements
                .Where(x => x.IsActive)
                .OrderByDescending(x => x.IsPinned)
                .ThenBy(x => x.DisplayOrder)
                .ThenByDescending(x => x.PublishDate)
                .ToListAsync();
        }

        public async Task<Announcement?> GetByIdAsync(int id)
        {
            return await _context.Announcements
                .FirstOrDefaultAsync(x => x.AnnouncementId == id && x.IsActive);
        }

        public async Task<List<Announcement>> GetLatestAsync(int count)
        {
            var today = DateTime.Today;

            return await _context.Announcements
                .Where(x =>
                    x.IsActive &&
                    x.IsPublished &&
                    x.PublishDate <= today &&
                    (x.ExpiryDate == null || x.ExpiryDate >= today))
                .OrderByDescending(x => x.IsPinned)
                .ThenBy(x => x.DisplayOrder)
                .ThenByDescending(x => x.PublishDate)
                .Take(count)
                .ToListAsync();
        }

        public async Task AddAsync(Announcement announcement)
        {
            await _context.Announcements.AddAsync(announcement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Announcement announcement)
        {
            _context.Announcements.Update(announcement);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Announcement>> SearchAsync(string? searchText)
        {
            var query = _context.Announcements
                .Where(x => x.IsActive);

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(x =>
                    x.Title.Contains(searchText) ||
                    x.Description.Contains(searchText));
            }

            return await query
                .OrderByDescending(x => x.IsPinned)
                .ThenBy(x => x.DisplayOrder)
                .ThenByDescending(x => x.PublishDate)
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
                return;

            entity.IsActive = false;
            entity.ModifiedDate = DateTime.Now;

            _context.Announcements.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Announcements
                .AnyAsync(x => x.AnnouncementId == id && x.IsActive);
        }
    }
}
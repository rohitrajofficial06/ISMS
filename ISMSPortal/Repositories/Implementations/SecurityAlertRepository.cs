using Microsoft.EntityFrameworkCore;
using ISMSPortal.Data;
using ISMSPortal.Models;
using ISMSPortal.Repositories.Interfaces;

namespace ISMSPortal.Repositories.Implementations
{
    public class SecurityAlertRepository : ISecurityAlertRepository
    {
        private readonly ApplicationDbContext _context;

        public SecurityAlertRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SecurityAlert>> GetAllAsync()
        {
            return await _context.SecurityAlerts
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .ThenByDescending(x => x.PublishDate)
                .ToListAsync();
        }

        public async Task<List<SecurityAlert>> SearchAsync(string? searchText)
        {
            return await _context.SecurityAlerts
                .Where(x => x.IsActive &&
                       (string.IsNullOrWhiteSpace(searchText) ||
                        x.Title.Contains(searchText)))
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
        }

        public async Task<SecurityAlert?> GetByIdAsync(int id)
        {
            return await _context.SecurityAlerts
                .FirstOrDefaultAsync(x => x.SecurityAlertId == id && x.IsActive);
        }

        public async Task<List<SecurityAlert>> GetLatestAsync(int count)
        {
            return await _context.SecurityAlerts
                .Where(x => x.IsActive && x.IsPublished)
                .OrderByDescending(x => x.PublishDate)
                .Take(count)
                .ToListAsync();
        }

        public async Task AddAsync(SecurityAlert entity)
        {
            await _context.SecurityAlerts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SecurityAlert entity)
        {
            _context.SecurityAlerts.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.SecurityAlerts.FindAsync(id);

            if (entity == null)
                return;

            entity.IsActive = false;
            entity.ModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.SecurityAlerts
                .AnyAsync(x => x.SecurityAlertId == id && x.IsActive);
        }
    }
}
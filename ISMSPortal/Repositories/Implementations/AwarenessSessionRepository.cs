using ISMSPortal.Data;
using ISMSPortal.Models;
using ISMSPortal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ISMSPortal.Repositories.Implementations
{
    public class AwarenessSessionRepository : IAwarenessSessionRepository
    {
        private readonly ApplicationDbContext _context;

        public AwarenessSessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AwarenessSession>> GetAllAsync()
        {
            return await _context.AwarenessSessions
                .Where(x => x.IsActive)
                .OrderBy(x => x.SessionDate)
                .ThenBy(x => x.StartTime)
                .ToListAsync();
        }

        public async Task<List<AwarenessSession>> SearchAsync(string? searchText)
        {
            return await _context.AwarenessSessions
                .Where(x => x.IsActive &&
                       (string.IsNullOrWhiteSpace(searchText) ||
                        x.SessionTitle.Contains(searchText) ||
                        x.Audience.Contains(searchText)))
                .OrderBy(x => x.SessionDate)
                .ToListAsync();
        }

        public async Task<AwarenessSession?> GetByIdAsync(int id)
        {
            return await _context.AwarenessSessions
                .FirstOrDefaultAsync(x => x.AwarenessSessionId == id && x.IsActive);
        }

        public async Task<List<AwarenessSession>> GetUpcomingSessionsAsync(int count)
        {
            var today = DateTime.Today;

            return await _context.AwarenessSessions
                .Where(x => x.IsActive &&
                            x.IsPublished &&
                            x.SessionDate >= today)
                .OrderBy(x => x.SessionDate)
                .ThenBy(x => x.StartTime)
                .Take(count)
                .ToListAsync();
        }

        public async Task AddAsync(AwarenessSession entity)
        {
            await _context.AwarenessSessions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AwarenessSession entity)
        {
            _context.AwarenessSessions.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.AwarenessSessions.FindAsync(id);

            if (entity == null)
                return;

            entity.IsActive = false;
            entity.ModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.AwarenessSessions
                .AnyAsync(x => x.AwarenessSessionId == id && x.IsActive);
        }
    }
}
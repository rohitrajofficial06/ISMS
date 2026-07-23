using ISMSPortal.Data;
using ISMSPortal.Models;
using ISMSPortal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ISMSPortal.Repositories.Implementations
{
    public class AwarenessProgressRepository : IAwarenessProgressRepository
    {
        private readonly ApplicationDbContext _context;

        public AwarenessProgressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AwarenessProgress?> GetAsync()
        {
            return await _context.AwarenessProgress
                .FirstOrDefaultAsync(x => x.IsActive);
        }

        public async Task UpdateAsync(AwarenessProgress entity)
        {
            _context.AwarenessProgress.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
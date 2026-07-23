using Microsoft.EntityFrameworkCore;
using ISMSPortal.Data;
using ISMSPortal.Models;
using ISMSPortal.Repositories.Interfaces;

namespace ISMSPortal.Repositories.Implementations
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly ApplicationDbContext _context;

        public PolicyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Policy>> GetAllAsync()
        {
            return await _context.Policies
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .ThenByDescending(x => x.EffectiveDate)
                .ToListAsync();
        }

        public async Task<List<Policy>> SearchAsync(string? searchText)
        {
            IQueryable<Policy> query = _context.Policies
                .Where(x => x.IsActive);

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.Trim();

                query = query.Where(x =>
                    x.PolicyCode.Contains(searchText) ||
                    x.PolicyName.Contains(searchText) ||
                    x.Category!.Contains(searchText) ||
                    x.Owner!.Contains(searchText));
            }

            return await query
                .OrderBy(x => x.DisplayOrder)
                .ThenByDescending(x => x.EffectiveDate)
                .ToListAsync();
        }

        public async Task<Policy?> GetByIdAsync(int id)
        {
            return await _context.Policies
                .FirstOrDefaultAsync(x =>
                    x.PolicyId == id &&
                    x.IsActive);
        }

        public async Task<List<Policy>> GetLatestAsync(int count)
        {
            return await _context.Policies
                .Where(x =>
                    x.IsActive &&
                    x.IsPublished)
                .OrderBy(x => x.DisplayOrder)
                .ThenByDescending(x => x.EffectiveDate)
                .Take(count)
                .ToListAsync();
        }

        public async Task AddAsync(Policy policy)
        {
            await _context.Policies.AddAsync(policy);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Policy policy)
        {
            _context.Policies.Update(policy);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Policies.FindAsync(id);

            if (entity == null)
                return;

            entity.IsActive = false;
            entity.ModifiedDate = DateTime.Now;

            _context.Policies.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Policies
                .AnyAsync(x =>
                    x.PolicyId == id &&
                    x.IsActive);
        }
    }
}
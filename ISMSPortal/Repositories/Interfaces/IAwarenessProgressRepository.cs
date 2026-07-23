using ISMSPortal.Models;

namespace ISMSPortal.Repositories.Interfaces
{
    public interface IAwarenessProgressRepository
    {
        Task<AwarenessProgress?> GetAsync();

        Task UpdateAsync(AwarenessProgress entity);
    }
}
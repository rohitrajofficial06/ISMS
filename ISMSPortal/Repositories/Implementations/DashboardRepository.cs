using ISMSPortal.Data;
using ISMSPortal.Repositories.Interfaces;
using ISMSPortal.ViewModels.Dashboard;
using Microsoft.EntityFrameworkCore;

namespace ISMSPortal.Repositories.Implementations
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //==========================================
        // Latest Policies
        //==========================================
        public async Task<List<LatestPolicyWidgetViewModel>> GetLatestPoliciesAsync(int count = 5)
        {
            return await _context.Policies
                .Where(x => x.IsActive)
                .OrderByDescending(x => x.EffectiveDate)
                .Take(count)
                .Select(x => new LatestPolicyWidgetViewModel
                {
                    PolicyId = x.PolicyId,
                    PolicyName = x.PolicyName,
                    IsUpdated = x.ReviewDate <= DateTime.Today
                })
                .ToListAsync();
        }

        //==========================================
        // Latest Security Alerts
        //==========================================
        public async Task<List<SecurityAlertWidgetViewModel>> GetLatestAlertsAsync(int count = 5)
        {
            return await _context.SecurityAlerts
                .Where(x => x.IsActive)
                .OrderByDescending(x => x.PublishDate)
                .Take(count)
                .Select(x => new SecurityAlertWidgetViewModel
                {
                    AlertId = x.SecurityAlertId,
                    Title = x.Title,
                    AlertType = x.Severity,
                    PublishDate = x.PublishDate
                })
                .ToListAsync();
        }

        //==========================================
        // Recent Documents
        //==========================================
        public async Task<List<RecentDocumentWidgetViewModel>> GetRecentDocumentsAsync(int count = 5)
        {
            return await _context.Documents
                .Where(x => x.IsActive && x.IsPublished)
                .OrderByDescending(x => x.EffectiveDate)
                .Take(count)
                .Select(x => new RecentDocumentWidgetViewModel
                {
                    DocumentId = x.DocumentId,
                    Title = x.DocumentName,
                    Category = x.Category,
                    EffectiveDate = x.EffectiveDate
                })
                .ToListAsync();
        }

        public async Task<List<AnnouncementWidgetViewModel>> GetLatestAnnouncementsAsync(int count = 5)
        {
            return await _context.Announcements
                .Where(x => x.IsActive)
                .OrderByDescending(x => x.IsPinned)
                .ThenByDescending(x => x.PublishDate)
                .Take(count)
                .Select(x => new AnnouncementWidgetViewModel
                {
                    AnnouncementId = x.AnnouncementId,
                    Title = x.Title,
                    Description = x.Description ?? string.Empty,
                    PublishDate = x.PublishDate,
                    IsPinned = x.IsPinned
                })
                .ToListAsync();
        }
    }
}
using ISMSPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace ISMSPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region DbSets

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AwarenessProgress> AwarenessProgress { get; set; }
        public DbSet<AwarenessSession> AwarenessSessions { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<QuickLink> QuickLinks { get; set; }
        public DbSet<SecurityAlert> SecurityAlerts { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedQuickLinks(modelBuilder);
        }

        #region Seed Data

        private static void SeedQuickLinks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuickLink>().HasData(
                new QuickLink
                {
                    QuickLinkId = 1,
                    Title = "ITS-IN Portal",
                    Url = "https://ykgwoffice.sharepoint.com/sites/YIL-ITSIN",
                    DisplayOrder = 1,
                    IconClass = "fas fa-home",
                    IsActive = true
                },
                new QuickLink
                {
                    QuickLinkId = 2,
                    Title = "ISMS Policies",
                    Url = "https://ykgwoffice.sharepoint.com/sites/YIL-ITSIN/ISMSPOLICIES/Forms/AllItems.aspx",
                    DisplayOrder = 2,
                    IconClass = "fas fa-file-alt",
                    IsActive = true
                },
                new QuickLink
                {
                    QuickLinkId = 3,
                    Title = "ISMS Training",
                    Url = "https://ykgwoffice.sharepoint.com/sites/YIL-ITSIN/ISMSTraining/Forms/AllItems.aspx",
                    DisplayOrder = 3,
                    IconClass = "fas fa-graduation-cap",
                    IsActive = true
                });
        }

        #endregion
    }
}
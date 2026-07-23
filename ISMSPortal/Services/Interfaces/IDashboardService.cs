using ISMSPortal.ViewModels.Dashboard;

namespace ISMSPortal.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> GetDashboardAsync();
    }
}
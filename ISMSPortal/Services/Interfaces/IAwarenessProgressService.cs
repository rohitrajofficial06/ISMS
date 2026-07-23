using ISMSPortal.ViewModels.Awareness;
using ISMSPortal.ViewModels.Dashboard;

public interface IAwarenessProgressService
{
    Task<AwarenessProgressViewModel> GetAsync();

    Task UpdateAsync(AwarenessProgressViewModel model);

    Task<AwarenessProgressWidgetViewModel> GetDashboardAsync();
}
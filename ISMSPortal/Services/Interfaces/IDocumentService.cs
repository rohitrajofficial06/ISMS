using ISMSPortal.ViewModels.Document;

namespace ISMSPortal.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<List<DocumentListViewModel>> GetAllAsync(string? searchText);

        Task<DocumentEditViewModel?> GetByIdAsync(int id);

        Task CreateAsync(DocumentCreateViewModel model);

        Task UpdateAsync(DocumentEditViewModel model);

        Task DeleteAsync(int id);

        Task<List<DocumentWidgetViewModel>> GetDashboardDocumentsAsync(int count = 5);
    }
}
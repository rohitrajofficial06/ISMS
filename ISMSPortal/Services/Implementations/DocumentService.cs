using AutoMapper;
using ISMSPortal.Helpers;
using ISMSPortal.Models;
using ISMSPortal.Repositories.Interfaces;
using ISMSPortal.Services.Interfaces;
using ISMSPortal.ViewModels.Document;

namespace ISMSPortal.Services.Implementations
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repository;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public DocumentService(
            IDocumentRepository repository,
            IWebHostEnvironment environment,
            IMapper mapper)
        {
            _repository = repository;
            _environment = environment;
            _mapper = mapper;
        }

        public async Task<List<DocumentListViewModel>> GetAllAsync(string? searchText)
        {
            var documents = string.IsNullOrWhiteSpace(searchText)
                ? await _repository.GetAllAsync()
                : await _repository.SearchAsync(searchText);

            return _mapper.Map<List<DocumentListViewModel>>(documents);
        }

        public async Task<DocumentEditViewModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                return null;

            return _mapper.Map<DocumentEditViewModel>(entity);
        }

        public async Task CreateAsync(DocumentCreateViewModel model)
        {
            ValidateDates(model.EffectiveDate, model.ExpiryDate);

            var entity = _mapper.Map<Document>(model);

            entity.AttachmentPath = await FileHelper.UploadFileAsync(
                _environment,
                model.Attachment,
                "documents");

            entity.CreatedDate = DateTime.Now;
            entity.IsActive = true;

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(DocumentEditViewModel model)
        {
            ValidateDates(model.EffectiveDate, model.ExpiryDate);

            var entity = await _repository.GetByIdAsync(model.DocumentId);

            if (entity == null)
                throw new Exception("Document not found.");

            entity.DocumentNumber = model.DocumentNumber;
            entity.DocumentName = model.DocumentName;
            entity.Category = model.Category;
            entity.Department = model.Department;
            entity.Owner = model.Owner;
            entity.Version = model.Version;
            entity.Description = model.Description;
            entity.EffectiveDate = model.EffectiveDate;
            entity.ExpiryDate = model.ExpiryDate;
            entity.IsPublished = model.IsPublished;
            entity.DisplayOrder = model.DisplayOrder;
            entity.ModifiedDate = DateTime.Now;

            if (model.Attachment != null)
            {
                FileHelper.DeleteFile(_environment, entity.AttachmentPath);

                entity.AttachmentPath = await FileHelper.UploadFileAsync(
                    _environment,
                    model.Attachment,
                    "documents");
            }

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Document not found.");

            FileHelper.DeleteFile(_environment, entity.AttachmentPath);

            await _repository.DeleteAsync(id);
        }

        public async Task<List<DocumentWidgetViewModel>> GetDashboardDocumentsAsync(int count = 5)
        {
            var documents = await _repository.GetLatestAsync(count);

            return _mapper.Map<List<DocumentWidgetViewModel>>(documents);
        }

        private static void ValidateDates(DateTime effectiveDate, DateTime? expiryDate)
        {
            if (expiryDate.HasValue && expiryDate.Value < effectiveDate)
                throw new Exception("Expiry Date cannot be earlier than Effective Date.");
        }
    }
}
using AutoMapper;
using ISMSPortal.Models;
using ISMSPortal.Repositories.Interfaces;
using ISMSPortal.Services.Interfaces;
using ISMSPortal.ViewModels.Policy;

namespace ISMSPortal.Services.Implementations
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository _repository;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public PolicyService(
            IPolicyRepository repository,
            IWebHostEnvironment environment,
            IMapper mapper)
        {
            _repository = repository;
            _environment = environment;
            _mapper = mapper;
        }

        public async Task<List<PolicyListViewModel>> GetAllAsync(string? searchText = null)
        {
            var policies = string.IsNullOrWhiteSpace(searchText)
                ? await _repository.GetAllAsync()
                : await _repository.SearchAsync(searchText);

            return _mapper.Map<List<PolicyListViewModel>>(policies);
        }

        public async Task<PolicyEditViewModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                return null;

            return _mapper.Map<PolicyEditViewModel>(entity);
        }

        public async Task CreateAsync(PolicyCreateViewModel model)
        {
            ValidateDates(model.EffectiveDate, model.ReviewDate);

            var entity = _mapper.Map<Policy>(model);

            entity.AttachmentPath = await UploadFileAsync(model.Attachment);

            entity.CreatedDate = DateTime.Now;
            entity.IsActive = true;

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(PolicyEditViewModel model)
        {
            ValidateDates(model.EffectiveDate, model.ReviewDate);

            var entity = await _repository.GetByIdAsync(model.PolicyId);

            if (entity == null)
                throw new Exception("Policy not found.");

            entity.PolicyCode = model.PolicyCode;
            entity.PolicyName = model.PolicyName;
            entity.Category = model.Category;
            entity.Description = model.Description;
            entity.Version = model.Version;
            entity.EffectiveDate = model.EffectiveDate;
            entity.ReviewDate = model.ReviewDate;
            entity.Owner = model.Owner;
            entity.IsPublished = model.IsPublished;
            entity.DisplayOrder = model.DisplayOrder;

            if (model.Attachment != null)
            {
                DeleteOldFile(entity.AttachmentPath);

                entity.AttachmentPath =
                    await UploadFileAsync(model.Attachment);
            }

            entity.ModifiedDate = DateTime.Now;

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Policy not found.");

            DeleteOldFile(entity.AttachmentPath);

            await _repository.DeleteAsync(id);
        }

        private static void ValidateDates(DateTime effectiveDate, DateTime? reviewDate)
        {
            if (reviewDate.HasValue &&
                reviewDate.Value.Date < effectiveDate.Date)
            {
                throw new Exception("Review Date cannot be earlier than Effective Date.");
            }
        }

        private async Task<string?> UploadFileAsync(IFormFile? file)
        {
            if (file == null || file.Length == 0)
                return null;

            string folder = Path.Combine(
                _environment.WebRootPath,
                "uploads",
                "policies");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string fileName =
                $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            string path = Path.Combine(folder, fileName);

            using FileStream stream = new(path, FileMode.Create);

            await file.CopyToAsync(stream);

            return $"/uploads/policies/{fileName}";
        }

        private void DeleteOldFile(string? filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return;

            string fullPath = Path.Combine(
                _environment.WebRootPath,
                filePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));

            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}
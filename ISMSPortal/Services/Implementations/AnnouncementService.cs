using AutoMapper;
using ISMSPortal.Models;
using ISMSPortal.Repositories.Interfaces;
using ISMSPortal.Services.Interfaces;
using ISMSPortal.ViewModels.Announcement;
using ISMSPortal.ViewModels.Dashboard;

namespace ISMSPortal.Services.Implementations
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _repository;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public AnnouncementService(
            IAnnouncementRepository repository,
            IWebHostEnvironment environment,
            IMapper mapper)
        {
            _repository = repository;
            _environment = environment;
            _mapper = mapper;
        }

        #region Public Methods

        public async Task<List<AnnouncementListViewModel>> GetAllAsync(string? searchText = null)
        {
            var announcements = string.IsNullOrWhiteSpace(searchText)
                ? await _repository.GetAllAsync()
                : await _repository.SearchAsync(searchText);

            return _mapper.Map<List<AnnouncementListViewModel>>(announcements);
        }

        public async Task<AnnouncementEditViewModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                return null;

            return _mapper.Map<AnnouncementEditViewModel>(entity);
        }

        public async Task CreateAsync(AnnouncementCreateViewModel model)
        {
            ValidateDates(model.PublishDate, model.ExpiryDate);

            var entity = _mapper.Map<Announcement>(model);

            entity.AttachmentPath = await UploadFileAsync(model.Attachment);

            entity.CreatedDate = DateTime.Now;
            entity.IsActive = true;

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(AnnouncementEditViewModel model)
        {
            ValidateDates(model.PublishDate, model.ExpiryDate);

            var entity = await _repository.GetByIdAsync(model.AnnouncementId);

            if (entity == null)
                throw new Exception("Announcement not found.");

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.PublishDate = model.PublishDate;
            entity.ExpiryDate = model.ExpiryDate;
            entity.IsPinned = model.IsPinned;
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
                throw new Exception("Announcement not found.");

            DeleteOldFile(entity.AttachmentPath);

            await _repository.DeleteAsync(id);
        }

        public async Task<List<AnnouncementWidgetViewModel>> GetDashboardAnnouncementsAsync(int count = 5)
        {
            var announcements = await _repository.GetLatestAsync(count);

            return _mapper.Map<List<AnnouncementWidgetViewModel>>(announcements);
        }

        #endregion

        #region Private Methods

        private static void ValidateDates(DateTime publishDate, DateTime? expiryDate)
        {
            if (expiryDate.HasValue &&
                expiryDate.Value.Date < publishDate.Date)
            {
                throw new Exception("Expiry Date cannot be earlier than Publish Date.");
            }
        }

        private async Task<string?> UploadFileAsync(IFormFile? file)
        {
            if (file == null || file.Length == 0)
                return null;

            string uploadFolder = Path.Combine(
                _environment.WebRootPath,
                "uploads",
                "announcements");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string fileName =
                $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            string fullPath = Path.Combine(uploadFolder, fileName);

            using FileStream stream = new(fullPath, FileMode.Create);

            await file.CopyToAsync(stream);

            return $"/uploads/announcements/{fileName}";
        }

        private void DeleteOldFile(string? filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return;

            string fullPath = Path.Combine(
                _environment.WebRootPath,
                filePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        #endregion
    }
}
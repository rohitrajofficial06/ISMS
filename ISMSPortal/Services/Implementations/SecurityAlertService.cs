using AutoMapper;
using ISMSPortal.Models;
using ISMSPortal.Repositories.Interfaces;
using ISMSPortal.Services.Interfaces;
using ISMSPortal.ViewModels.SecurityAlert;

namespace ISMSPortal.Services.Implementations
{
    public class SecurityAlertService : ISecurityAlertService
    {
        private readonly ISecurityAlertRepository _repository;
        private readonly IMapper _mapper;

        public SecurityAlertService(
            ISecurityAlertRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SecurityAlertListViewModel>> GetAllAsync(string? searchText)
        {
            var alerts = string.IsNullOrWhiteSpace(searchText)
                ? await _repository.GetAllAsync()
                : await _repository.SearchAsync(searchText);

            return _mapper.Map<List<SecurityAlertListViewModel>>(alerts);
        }

        public async Task<SecurityAlertEditViewModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return entity == null
                ? null
                : _mapper.Map<SecurityAlertEditViewModel>(entity);
        }

        public async Task CreateAsync(SecurityAlertCreateViewModel model)
        {
            var entity = _mapper.Map<SecurityAlert>(model);

            entity.CreatedDate = DateTime.Now;
            entity.IsActive = true;

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(SecurityAlertEditViewModel model)
        {
            var entity = await _repository.GetByIdAsync(model.SecurityAlertId);

            if (entity == null)
                throw new Exception("Security Alert not found.");

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.Severity = model.Severity;
            entity.PublishDate = model.PublishDate;
            entity.IsPublished = model.IsPublished;
            entity.DisplayOrder = model.DisplayOrder;
            entity.ModifiedDate = DateTime.Now;

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<SecurityAlertWidgetViewModel>> GetDashboardAlertsAsync(int count = 5)
        {
            var alerts = await _repository.GetLatestAsync(count);

            return _mapper.Map<List<SecurityAlertWidgetViewModel>>(alerts);
        }
    }
}
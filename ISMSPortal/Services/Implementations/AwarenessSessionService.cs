using AutoMapper;
using ISMSPortal.Models;
using ISMSPortal.Repositories.Interfaces;
using ISMSPortal.Services.Interfaces;
using ISMSPortal.ViewModels.Awareness;

namespace ISMSPortal.Services.Implementations
{
    public class AwarenessSessionService : IAwarenessSessionService
    {
        private readonly IAwarenessSessionRepository _repository;
        private readonly IMapper _mapper;

        public AwarenessSessionService(
            IAwarenessSessionRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AwarenessSessionListViewModel>> GetAllAsync(string? searchText)
        {
            var sessions = string.IsNullOrWhiteSpace(searchText)
                ? await _repository.GetAllAsync()
                : await _repository.SearchAsync(searchText);

            return _mapper.Map<List<AwarenessSessionListViewModel>>(sessions);
        }

        public async Task<AwarenessSessionEditViewModel?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return entity == null
                ? null
                : _mapper.Map<AwarenessSessionEditViewModel>(entity);
        }

        public async Task CreateAsync(AwarenessSessionCreateViewModel model)
        {
            var entity = _mapper.Map<AwarenessSession>(model);

            entity.CreatedDate = DateTime.Now;
            entity.IsActive = true;

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(AwarenessSessionEditViewModel model)
        {
            var entity = await _repository.GetByIdAsync(model.AwarenessSessionId);

            if (entity == null)
                throw new Exception("Awareness Session not found.");

            entity.SessionTitle = model.SessionTitle;
            entity.Description = model.Description;
            entity.SessionDate = model.SessionDate;
            entity.StartTime = model.StartTime;
            entity.EndTime = model.EndTime;
            entity.Audience = model.Audience;
            entity.Trainer = model.Trainer;
            entity.Venue = model.Venue;
            entity.IsPublished = model.IsPublished;
            entity.DisplayOrder = model.DisplayOrder;
            entity.ModifiedDate = DateTime.Now;

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<AwarenessSessionWidgetViewModel>> GetUpcomingSessionsAsync(int count = 5)
        {
            var sessions = await _repository.GetUpcomingSessionsAsync(count);

            return _mapper.Map<List<AwarenessSessionWidgetViewModel>>(sessions);
        }
    }
}
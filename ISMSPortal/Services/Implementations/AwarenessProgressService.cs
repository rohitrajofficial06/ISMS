using AutoMapper;
using ISMSPortal.Repositories.Interfaces;
using ISMSPortal.Services.Interfaces;
using ISMSPortal.ViewModels.Awareness;
using ISMSPortal.ViewModels.Dashboard;

namespace ISMSPortal.Services.Implementations
{
    public class AwarenessProgressService : IAwarenessProgressService
    {
        private readonly IAwarenessProgressRepository _repository;
        private readonly IMapper _mapper;

        public AwarenessProgressService(
            IAwarenessProgressRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AwarenessProgressViewModel> GetAsync()
        {
            var entity = await _repository.GetAsync();

            if (entity == null)
                return new AwarenessProgressViewModel();

            return _mapper.Map<AwarenessProgressViewModel>(entity);
        }

        public async Task UpdateAsync(AwarenessProgressViewModel model)
        {
            var entity = await _repository.GetAsync();

            if (entity == null)
                throw new Exception("Awareness Progress record not found.");

            entity.TargetEmployees = model.TargetEmployees;
            entity.SessionsConducted = model.SessionsConducted;
            entity.EmployeesAttended = model.EmployeesAttended;
            entity.PendingEmployees = model.PendingEmployees;
            entity.ModifiedDate = DateTime.Now;

            await _repository.UpdateAsync(entity);
        }

        public async Task<AwarenessProgressWidgetViewModel> GetDashboardAsync()
        {
            var entity = await _repository.GetAsync();

            if (entity == null)
            {
                return new AwarenessProgressWidgetViewModel
                {
                    Title = "Awareness Campaign Progress",
                    Completed = 0,
                    Total = 0,
                    ProgressColor = "success"
                };
            }

            return new AwarenessProgressWidgetViewModel
            {
                Title = "Awareness Campaign Progress",
                Completed = entity.EmployeesAttended,
                Total = entity.TargetEmployees,
                ProgressColor = "success"
            };
        }
    }
}
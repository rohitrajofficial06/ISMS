namespace ISMSPortal.ViewModels.Awareness
{
    public class AwarenessProgressViewModel
    {
        public int AwarenessProgressId { get; set; }

        public int TargetEmployees { get; set; }

        public int SessionsConducted { get; set; }

        public int EmployeesAttended { get; set; }

        public int PendingEmployees { get; set; }

        public int CompletedPercentage =>
            TargetEmployees == 0
                ? 0
                : (EmployeesAttended * 100) / TargetEmployees;
    }
}
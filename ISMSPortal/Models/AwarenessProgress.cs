using System.ComponentModel.DataAnnotations;

namespace ISMSPortal.Models
{
    public class AwarenessProgress : BaseEntity
    {
        [Key]
        public int AwarenessProgressId { get; set; }

        public int TargetEmployees { get; set; }

        public int SessionsConducted { get; set; }

        public int EmployeesAttended { get; set; }

        public int PendingEmployees { get; set; }
    }
}
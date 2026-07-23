namespace ISMSPortal.Models
{
    public abstract class BaseEntity
    {
        public bool IsActive { get; set; } = true;

        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
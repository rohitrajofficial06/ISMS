using System.ComponentModel.DataAnnotations;

namespace ISMSPortal.Models
{
    public class SecurityAlert : BaseEntity
    {
        [Key]
        public int SecurityAlertId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Severity { get; set; } = "Medium";

        public DateTime PublishDate { get; set; }

        public bool IsPublished { get; set; }

        public int DisplayOrder { get; set; }
    }
}
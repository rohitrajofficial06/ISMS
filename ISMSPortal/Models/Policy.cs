using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISMSPortal.Models
{
    [Table("Policies")]
    public class Policy : BaseEntity
    {
        [Key]
        public int PolicyId { get; set; }

        [Required]
        [StringLength(50)]
        public string PolicyCode { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string PolicyName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Category { get; set; }

        public string? Description { get; set; }

        [StringLength(20)]
        public string Version { get; set; } = "1.0";

        public DateTime EffectiveDate { get; set; }

        public DateTime? ReviewDate { get; set; }

        [StringLength(100)]
        public string? Owner { get; set; }

        [StringLength(500)]
        public string? AttachmentPath { get; set; }

        public bool IsPublished { get; set; }

        public int DisplayOrder { get; set; }
    }
}
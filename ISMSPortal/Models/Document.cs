using System.ComponentModel.DataAnnotations;

namespace ISMSPortal.Models
{
    public class Document : BaseEntity
    {
        [Key]
        public int DocumentId { get; set; }

        [Required]
        [StringLength(50)]
        public string DocumentNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string DocumentName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Category { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Department { get; set; }

        [StringLength(100)]
        public string? Owner { get; set; }

        [StringLength(20)]
        public string Version { get; set; } = "1.0";

        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }

        public string? Description { get; set; }

        [StringLength(500)]
        public string? AttachmentPath { get; set; }

        public bool IsPublished { get; set; }

        public int DisplayOrder { get; set; }
    }
}
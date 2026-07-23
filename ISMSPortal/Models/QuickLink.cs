using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISMSPortal.Models
{
    [Table("MST_QuickLinks")]
    public class QuickLink : BaseEntity
    {
        [Key]
        public int QuickLinkId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Url { get; set; } = string.Empty;

        public int DisplayOrder { get; set; }

        public string? IconClass { get; set; }
    }
}
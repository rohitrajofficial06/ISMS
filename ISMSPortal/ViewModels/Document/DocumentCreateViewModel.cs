using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ISMSPortal.ViewModels.Document
{
    public class DocumentCreateViewModel
    {
        [Required(ErrorMessage = "Document Number is required.")]
        [Display(Name = "Document Number")]
        public string DocumentNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Document Name is required.")]
        [Display(Name = "Document Name")]
        public string DocumentName { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        public string? Department { get; set; }

        public string? Owner { get; set; }

        public string Version { get; set; } = "1.0";

        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; } = DateTime.Today;

        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }

        public string? Description { get; set; }

        public IFormFile? Attachment { get; set; }

        [Display(Name = "Published")]
        public bool IsPublished { get; set; } = true;

        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; } = 1;
    }
}
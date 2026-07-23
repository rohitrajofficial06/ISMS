using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ISMSPortal.ViewModels.Policy
{
    public class PolicyBaseViewModel
    {
        [Required]
        [Display(Name = "Policy Code")]
        public string PolicyCode { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Policy Name")]
        public string PolicyName { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public string? Category { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Version")]
        public string Version { get; set; } = "1.0";

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Effective Date")]
        public DateTime EffectiveDate { get; set; } = DateTime.Today;

        [DataType(DataType.Date)]
        [Display(Name = "Review Date")]
        public DateTime? ReviewDate { get; set; }

        [Display(Name = "Policy Owner")]
        public string? Owner { get; set; }

        [Display(Name = "Attachment")]
        public IFormFile? Attachment { get; set; }

        public string? AttachmentPath { get; set; }

        [Display(Name = "Published")]
        public bool IsPublished { get; set; } = true;

        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; } = 1;
    }
}
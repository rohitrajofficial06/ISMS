using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ISMSPortal.ViewModels.Document
{
    public class DocumentEditViewModel
    {
        public int DocumentId { get; set; }

        [Required]
        public string DocumentNumber { get; set; } = string.Empty;

        [Required]
        public string DocumentName { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        public string? Department { get; set; }

        public string? Owner { get; set; }

        public string Version { get; set; } = "1.0";

        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }

        public string? Description { get; set; }

        public string? AttachmentPath { get; set; }

        public IFormFile? Attachment { get; set; }

        public bool IsPublished { get; set; }

        public int DisplayOrder { get; set; }
    }
}
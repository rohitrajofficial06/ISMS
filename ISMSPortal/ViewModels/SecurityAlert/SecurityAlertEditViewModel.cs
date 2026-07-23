using System.ComponentModel.DataAnnotations;

namespace ISMSPortal.ViewModels.SecurityAlert
{
    public class SecurityAlertEditViewModel
    {
        public int SecurityAlertId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Severity { get; set; } = "Medium";

        public DateTime PublishDate { get; set; }

        public bool IsPublished { get; set; }

        public int DisplayOrder { get; set; }
    }
}
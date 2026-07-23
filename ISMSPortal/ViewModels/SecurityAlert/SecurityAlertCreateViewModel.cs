using System.ComponentModel.DataAnnotations;

namespace ISMSPortal.ViewModels.SecurityAlert
{
    public class SecurityAlertCreateViewModel
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Severity { get; set; } = "Medium";

        public DateTime PublishDate { get; set; } = DateTime.Today;

        public bool IsPublished { get; set; } = true;

        public int DisplayOrder { get; set; } = 1;
    }
}
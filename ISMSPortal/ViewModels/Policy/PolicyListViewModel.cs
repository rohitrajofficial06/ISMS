namespace ISMSPortal.ViewModels.Policy
{
    public class PolicyListViewModel
    {
        public int PolicyId { get; set; }

        public string PolicyCode { get; set; } = string.Empty;

        public string PolicyName { get; set; } = string.Empty;

        public string? Category { get; set; }

        public string? Description { get; set; }

        public string Version { get; set; } = string.Empty;

        public DateTime EffectiveDate { get; set; }

        public DateTime? ReviewDate { get; set; }

        public string? Owner { get; set; }

        public string? AttachmentPath { get; set; }

        public bool IsPublished { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }
    }
}
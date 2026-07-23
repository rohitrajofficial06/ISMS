namespace ISMSPortal.ViewModels.Dashboard
{
    public class LatestPolicyWidgetViewModel
    {
        public int PolicyId { get; set; }

        public string PolicyName { get; set; } = string.Empty;

        public bool IsUpdated { get; set; }
    }
}
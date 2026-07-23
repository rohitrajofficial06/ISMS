namespace ISMSPortal.ViewModels.Dashboard
{
    public class AwarenessProgressWidgetViewModel
    {
        public string Title { get; set; } = string.Empty;

        public int Completed { get; set; }

        public int Total { get; set; }

        public int Percentage
        {
            get
            {
                if (Total == 0)
                    return 0;

                return (Completed * 100) / Total;
            }
        }

        public string ProgressColor { get; set; } = "success";
    }
}
namespace ISMSPortal.Configuration
{
    public class ApplicationSettings
    {
        public string ApplicationName { get; set; } = string.Empty;

        public string Version { get; set; } = string.Empty;

        public string DocumentUploadPath { get; set; } = string.Empty;

        public string PolicyUploadPath { get; set; } = string.Empty;

        public string AnnouncementUploadPath { get; set; } = string.Empty;

        public string TrainingUploadPath { get; set; } = string.Empty;
    }
}
public class AwarenessCalendarViewModel
{
    public int SessionId { get; set; }

    public DateTime SessionDate { get; set; }

    public string Title { get; set; }

    public string Audience { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public string Month =>
        SessionDate.ToString("MMM").ToUpper();

    public int Day =>
        SessionDate.Day;
}
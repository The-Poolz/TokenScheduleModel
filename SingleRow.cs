namespace TokenSchedule;

public class SingleRow
{
    public SingleRow(decimal ratio, DateTime startTime, DateTime? endTime = null)
    {
        if (EndTime.HasValue && StartTime > EndTime.Value)
        {
            throw new ArgumentException("End time must be greater than or equal to start time.", nameof(StartTime));
        }
        if (Ratio <= 0)
        {
            throw new ArgumentException("Ratio must be positive.", nameof(ratio));
        }
        Ratio = ratio;
        StartTime = startTime;
        EndTime = endTime;
    }

    public decimal Ratio { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}

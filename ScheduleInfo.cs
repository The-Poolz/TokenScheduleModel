namespace TokenSchedule
{
    public class ScheduleInfo
    {
        private readonly IEnumerable<SingleRow> rows;
        public ScheduleInfo(IEnumerable<SingleRow> data)
        {
            ValidateData(data);
            rows = data;
        }
        public SingleRow GetTge() => rows.FirstOrDefault()!;
        public IEnumerable<SingleRow> GetRest() => IsOnlyTge() ? Array.Empty<SingleRow>() : rows.Skip(1);
        public bool IsOnlyTge() => rows.Count() == 1;
        internal static void ValidateData(IEnumerable<SingleRow> data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (!data.Any()) throw new ArgumentException("Data must Have elemets");
            if (data.Sum(x => x.Ratio) != 1) throw new ArgumentException("Ratio Sum Need to be 1");
            if (data.Min(x => x.Ratio) <= 0) throw new ArgumentException("Ratio Must be Posative");
            if (data.Any(x => x.EndTime != null && x.StartTime > x.EndTime)) throw new ArgumentException("EndTime Must be greater than StartTime");
            if (data.FirstOrDefault()!.StartTime == data.Min(x => x.StartTime)) throw new ArgumentException("First Element Must be TGE - First");
        }
    }
    public class SingleRow
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal Ratio { get; set; }
    }
}

namespace TimingDemo.Api.Options
{
    public class PerformanceOptions
    {
        public const string SectionName = "Performance";
        public int SlowRequestThresholdMs { get; set; } = 1000;
    }
}

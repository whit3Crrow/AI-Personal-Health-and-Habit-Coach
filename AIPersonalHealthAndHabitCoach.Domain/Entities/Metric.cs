using AIPersonalHealthAndHabitCoach.Domain.Enums;

namespace AIPersonalHealthAndHabitCoach.Domain.Entities
{
    public abstract class Metric
    {
        public Guid Id { get; set; }
        public DateTime StartDateTimeUtc { get; set; }
        public MetricType Type { get; set; }
        public abstract List<string> GetTags();
    }
}
namespace AIPersonalHealthAndHabitCoach.Domain.Entities
{
    public abstract class Metric
    {
        public Guid Id { get; set; }
        public DateTime StartDateTimeUtc { get; set; }
    }
}
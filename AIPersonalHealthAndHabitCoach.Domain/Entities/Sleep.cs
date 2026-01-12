using AIPersonalHealthAndHabitCoach.Domain.Enums;

namespace AIPersonalHealthAndHabitCoach.Domain.Entities
{
    public class Sleep : Metric
    {
        public int DurationMinutes { get; set; }
        public SleepQuality Quality { get; set; }
    }
}
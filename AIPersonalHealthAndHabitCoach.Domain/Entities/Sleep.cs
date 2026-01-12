using AIPersonalHealthAndHabitCoach.Domain.Enums;

namespace AIPersonalHealthAndHabitCoach.Domain.Entities
{
    public class Sleep : Metrics
    {
        public int DurationMinutes { get; set; }

        public SleepQuality Quality { get; set; }
    }
}
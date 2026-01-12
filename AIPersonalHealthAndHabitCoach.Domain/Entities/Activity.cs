using AIPersonalHealthAndHabitCoach.Domain.Enums;

namespace AIPersonalHealthAndHabitCoach.Domain.Entities
{
    public class Activity : Metrics
    {
        public string Description { get; set; } = string.Empty;
        public int CaloriesBurned { get; set; }
        public ActivityType Type { get; set; }
    }
}
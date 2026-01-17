using AIPersonalHealthAndHabitCoach.Domain.Enums;

namespace AIPersonalHealthAndHabitCoach.Domain.Entities
{
    public class Activity : Metric
    {
        public string Description { get; set; } = string.Empty;
        public int CaloriesBurned { get; set; }
        public ActivityType ActivityType { get; set; }
    }
}

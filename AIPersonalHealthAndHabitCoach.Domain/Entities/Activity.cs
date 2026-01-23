using AIPersonalHealthAndHabitCoach.Domain.Enums;

namespace AIPersonalHealthAndHabitCoach.Domain.Entities
{
    public class Activity : Metric
    {
        public string Description { get; set; } = string.Empty;
        public int CaloriesBurned { get; set; }
        public ActivityType ActivityType { get; set; }

        public override List<string> GetTags()
        {
            var tags = new List<string>
            {
                {ActivityType.ToString()}
            };

            if (CaloriesBurned > 0 && CaloriesBurned < 150)
            {
                tags.Add("Active Recovery");
            }
            else if (CaloriesBurned >= 150 && CaloriesBurned <= 500)
            {
                tags.Add("Moderate Workout");
            }
            else if (CaloriesBurned > 500)
            {
                tags.Add("High Intensity");
            }

            if (CaloriesBurned > 400)
            {
                tags.Add("Fat Burner");
            }
            
            if (CaloriesBurned > 800)
            {
                tags.Add("Endurance Master");
            }

            return tags;
        }
    }
}
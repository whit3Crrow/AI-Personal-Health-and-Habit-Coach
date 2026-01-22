using AIPersonalHealthAndHabitCoach.Domain.Enums;

namespace AIPersonalHealthAndHabitCoach.Domain.Entities
{
    public class Sleep : Metric
    {
        public int DurationMinutes { get; set; }
        public SleepQuality SleepQuality { get; set; }

        public override List<string> GetTags()
        {
            var tags = new List<string>
            {
                {SleepQuality.ToString()}
            };

            if (DurationMinutes > 0 && DurationMinutes <= 45)
            {
                tags.Add("Power Nap");
            }
            else if (DurationMinutes > 45 && DurationMinutes < 360)
            {
                tags.Add("Sleep Debt");
            }
            else if (DurationMinutes >= 420 && DurationMinutes <= 540)
            {
                tags.Add("Optimal Rest");
            }
            else if (DurationMinutes > 540)
            {
                tags.Add("Long Sleep");
            }

            if (DurationMinutes >= 420 && SleepQuality == SleepQuality.Good)
            {
                tags.Add("Deep Regeneration");
            }

            return tags;
        }
    }
}
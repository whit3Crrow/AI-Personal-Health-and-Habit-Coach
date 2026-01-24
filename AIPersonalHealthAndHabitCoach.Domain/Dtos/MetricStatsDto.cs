using AIPersonalHealthAndHabitCoach.Domain.Enums;

namespace AIPersonalHealthAndHabitCoach.Domain.Dtos
{
    public class MetricStatsDto
    {
        public decimal? AverageCaloriesBurnedPerDay { get; set; }
        public decimal? AverageProteinGramsPerDay { get; set; }
        public decimal? AverageCarbonGramsPerDay { get; set; }
        public decimal? AverageFatGramsPerDay { get; set; }
        public decimal? AverageSleepDurationMinutesPerDay { get; set; }
        public ActivityType? MostPopularActivityType { get; set; }
        public SleepQuality? MostPopularSleepQuality { get; set; }
    }
}

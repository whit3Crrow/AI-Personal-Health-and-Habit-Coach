using AIPersonalHealthAndHabitCoach.Domain.Enums;

namespace AIPersonalHealthAndHabitCoach.Domain.Dtos
{
    public class MetricDetailDto
    {
        public Guid Id { get; set; }
        public DateTime StartDateTimeUtc { get; set; }
        public MetricType Type { get; set; }
        public int? DurationMinutes { get; set; }
        public SleepQuality? SleepQuality { get; set; }
        public string? Description { get; set; }
        public decimal? ProteinGrams { get; set; }
        public decimal? CarbonGrams { get; set; }
        public decimal? FatGrams { get; set; }
        public int? CaloriesBurned { get; set; } 
        public ActivityType? ActivityType { get; set; }
        public List<string> Tags { get; set; } = [];
    }
}
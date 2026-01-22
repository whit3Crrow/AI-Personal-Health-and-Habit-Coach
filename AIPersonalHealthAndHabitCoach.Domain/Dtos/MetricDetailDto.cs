using AIPersonalHealthAndHabitCoach.Domain.Enums;
using System.Text.Json.Serialization; // To jest kluczowe dla działania JsonIgnore

namespace AIPersonalHealthAndHabitCoach.Domain.Dtos
{
    public class MetricDetailDto
    {
        public Guid Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? Date { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SleepQuality? SleepQuality { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DurationMinutes { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? ProteinGrams { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? CarbonGrams { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? FatGrams { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? CaloriesBurned { get; set; } 

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ActivityType? ActivityType { get; set; }

        public List<string> Tags { get; set; } = new();
    }
}
using AIPersonalHealthAndHabitCoach.Domain.Enums;

namespace AIPersonalHealthAndHabitCoach.Domain.Dtos
{
    public class MetricStatsTypeQueryDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MetricType MetricType { get; set; }
    }
}
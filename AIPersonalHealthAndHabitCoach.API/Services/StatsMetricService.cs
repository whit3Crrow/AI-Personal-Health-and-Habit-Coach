using System;

namespace AIPersonalHealthAndHabitCoach.API.Services
{
    public class StatsMetricService : IStatsMetricService
    {
        public string GetSummary(Guid userId)
        {
            return "Tu będzie podsumowanie statystyk";
        }

        public string GetSpecific(Guid userId, string metricType)
        {
            return $"Szczegółowe statystyki dla: {metricType}";
        }
    }
}
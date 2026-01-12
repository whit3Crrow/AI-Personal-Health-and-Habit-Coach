using System;

namespace AIPersonalHealthAndHabitCoach.API.Services
{
    public interface IStatsMetricService
    {
        string GetSummary(Guid userId);
        string GetSpecific(Guid userId, string metricType);
    }
}
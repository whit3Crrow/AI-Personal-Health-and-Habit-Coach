using System;

namespace AIPersonalHealthAndHabitCoach.Domain.Entities
{
    public abstract class Metrics
    {
        public Guid Id { get; set; }
        public DateTime StartDateTimeUtc { get; set; }
    }
}
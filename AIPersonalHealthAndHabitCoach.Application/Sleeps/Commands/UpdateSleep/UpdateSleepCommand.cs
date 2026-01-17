using AIPersonalHealthAndHabitCoach.Domain.Enums;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Sleeps.Commands.UpdateSleep
{
    public class UpdateSleepCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required int DurationMinutes { get; set; }
        public required SleepQuality SleepQuality { get; set; }
        public required DateTime StartDate { get; set; }
    }
}
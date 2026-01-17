using AIPersonalHealthAndHabitCoach.Domain.Enums;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Activities.Commands.UpdateActivity
{
    public class UpdateActivityCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Description { get; set; }
        public required int CaloriesBurned { get; set; }
        public required ActivityType ActivityType { get; set; }
        public required DateTime StartDate { get; set; }
    }
}
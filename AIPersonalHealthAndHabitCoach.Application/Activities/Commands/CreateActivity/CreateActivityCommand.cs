using AIPersonalHealthAndHabitCoach.Domain.Enums;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommand : IRequest<Guid>
    {
        public required string Description { get; set; }
        public required int CaloriesBurned { get; set; }
        public required ActivityType ActivityType { get; set; }
    }
}
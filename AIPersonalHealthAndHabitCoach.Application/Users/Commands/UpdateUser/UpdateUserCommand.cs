using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Guid>
    {
        public required decimal WeightKilograms { get; set; }
        public required decimal HeightCentimeters { get; set; }
        public required int Age { get; set; }
    }
}

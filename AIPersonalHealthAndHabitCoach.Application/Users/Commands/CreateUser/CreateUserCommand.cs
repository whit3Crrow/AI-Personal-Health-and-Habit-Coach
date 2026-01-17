using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public required decimal WeightKilograms { get; set; }
        public required decimal HeightCentimeters { get; set; }
        public required int Age { get; set; }
    }
}

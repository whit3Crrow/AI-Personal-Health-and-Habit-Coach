using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public decimal WeightKilograms { get; set; }
        public decimal HeightCentimeters { get; set; }
        public int Age { get; set; }
    }
}

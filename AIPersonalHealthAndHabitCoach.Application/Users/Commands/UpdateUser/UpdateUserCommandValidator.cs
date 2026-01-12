using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.WeightKilograms)
                .InclusiveBetween(30, 350)
                .WithMessage("Weight must be between 30 and 350 kg.");

            RuleFor(x => x.HeightCentimeters)
                .InclusiveBetween(100, 250)
                .WithMessage("Height must be between 100 and 250 cm.");

            RuleFor(x => x.Age)
                .InclusiveBetween(13, 120)
                .WithMessage("Age must be between 13 and 120 years.");
        }
    }
}

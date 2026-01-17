using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand>
    {
        public CreateActivityCommandValidator()
        {
            RuleFor(x => x.Description)
                .MaximumLength(512)
                .WithMessage("Description must not exceed 512 characters.");

            RuleFor(x => x.CaloriesBurned)
                .GreaterThan(0)
                .WithMessage("Calories burned must be greater than 0.");

            RuleFor(x => x.ActivityType)
                .IsInEnum()
                .WithMessage("Invalid activity type.");
        }
    }
}
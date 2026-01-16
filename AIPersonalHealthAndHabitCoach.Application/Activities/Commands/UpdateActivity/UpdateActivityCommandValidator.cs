using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Activities.Commands.UpdateActivity
{
    public class UpdateActivityCommandValidator : AbstractValidator<UpdateActivityCommand>
    {
        public UpdateActivityCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Activity ID is required.");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(200).WithMessage("Description must not exceed 200 characters.");

            RuleFor(v => v.CaloriesBurned)
                .GreaterThan(0).WithMessage("Calories burned must be greater than 0.");

            RuleFor(v => v.ActivityType)
                .IsInEnum().WithMessage("Invalid activity type.");
        }
    }
}
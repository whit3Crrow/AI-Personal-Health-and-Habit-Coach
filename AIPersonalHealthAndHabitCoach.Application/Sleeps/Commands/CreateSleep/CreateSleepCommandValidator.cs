using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Sleeps.Commands.CreateSleep
{
    public class CreateActivityCommandValidator : AbstractValidator<CreateSleepCommand>
    {
        public CreateActivityCommandValidator()
        {
            RuleFor(x => x.DurationMinutes)
                .GreaterThan(0)
                .WithMessage("Sleep duration must be greater than 0 minutes.")
                .LessThan(24 * 60)
                .WithMessage("Sleep duration cannot exceed 24 hours.");

            RuleFor(x => x.SleepQuality)
                .IsInEnum()
                .WithMessage("Invalid sleep quality value.");
        }
    }
}

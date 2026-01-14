using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Sleeps.Commands.CreateSleep
{
    public class CreateSleepCommandValidator : AbstractValidator<CreateSleepCommand>
    {
        public CreateSleepCommandValidator()
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

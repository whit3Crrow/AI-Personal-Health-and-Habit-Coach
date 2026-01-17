using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Metrics.Commands.DeleteMetricById
{
    public class DeleteMetricByIdCommandValidator : AbstractValidator<DeleteMetricByIdCommand>
    {
        public DeleteMetricByIdCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Metric ID cannot be empty.");
        }
    }
}
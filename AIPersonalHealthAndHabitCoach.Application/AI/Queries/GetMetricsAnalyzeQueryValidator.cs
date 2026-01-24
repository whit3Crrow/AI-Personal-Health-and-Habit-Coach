using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.AI.Queries
{
    public class GetMetricsAnalyzeQueryValidator : AbstractValidator<GetMetricsAnalyzeQuery>
    {
        public GetMetricsAnalyzeQueryValidator()
        {
            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate)
                .WithMessage("End date cannot be earlier than start date.");

            RuleFor(x => x)
                .Must(x => x.EndDate <= x.StartDate.AddMonths(3))
                .When(x => x.EndDate > x.StartDate)
                .WithMessage("The date range cannot exceed 3 months.");

            RuleFor(x => x.Question)
                .MaximumLength(512)
                .WithMessage("Question cannot exceed 512 characters.");
        }
    }
}
using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Stats.Queries.GetMetricsSummary
{
    public class GetMetricsSummaryValidator : AbstractValidator<GetMetricsSummaryQuery>
    {
        public GetMetricsSummaryValidator()
        {
            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate)
                .WithMessage("End date cannot be earlier than start date.");

            RuleFor(x => x)
                .Must(x => x.EndDate <= x.StartDate.AddMonths(3))
                .When(x => x.EndDate > x.StartDate)
                .WithMessage("The date range cannot exceed 3 months.");
        }
    }
}
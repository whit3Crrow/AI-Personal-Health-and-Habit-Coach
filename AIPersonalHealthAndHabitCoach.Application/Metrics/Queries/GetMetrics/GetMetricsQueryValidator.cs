using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Metrics.Queries.GetMetrics
{
    public class GetMetricsQueryValidator : AbstractValidator<GetMetricsQuery>
    {
        public GetMetricsQueryValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page number must be at least 1.");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100)
                .WithMessage("Page size must be between 1 and 100.");

            RuleForEach(x => x.MetricTypes)
                .IsInEnum()
                .WithMessage("One or more metric types are invalid.");
        }
    }
}
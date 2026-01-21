using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Stats.Queries.GetMetricsSummary
{
    public class GetMetricsSummaryValidator : AbstractValidator<GetMetricsSummaryQuery>
    {
        public GetMetricsSummaryValidator()
        {
            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate)
                .WithMessage("Data końcowa (To) musi być późniejsza lub równa dacie początkowej (From).");
        }
    }
}
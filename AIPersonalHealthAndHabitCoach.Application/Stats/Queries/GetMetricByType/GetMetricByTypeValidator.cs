using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Stats.Queries.GetMetricByType
{
    public class GetMetricByTypeValidator : AbstractValidator<GetMetricByTypeQuery>
    {
        public GetMetricByTypeValidator()
        {
            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate)
                .WithMessage("Data końcowa (To) musi być późniejsza lub równa dacie początkowej (From).");

            RuleFor(x => x.MetricType)
                .IsInEnum()
                .WithMessage("Nieprawidłowy typ metryki.");
        }
    }
}
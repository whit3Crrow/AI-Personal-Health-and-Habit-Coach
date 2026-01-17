using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Metrics.Queries.GetMetricById
{
    public class GetMetricByIdQueryValidator : AbstractValidator<GetMetricByIdQuery>
    {
        public GetMetricByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required.");
        }
    }
}
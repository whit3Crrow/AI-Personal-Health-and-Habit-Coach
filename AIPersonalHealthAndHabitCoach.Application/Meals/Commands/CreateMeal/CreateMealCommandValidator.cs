using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Meals.Commands.CreateMeal
{
    public class CreateMealCommandValidator : AbstractValidator<CreateMealCommand>
    {
        public CreateMealCommandValidator()
        {
            RuleFor(x => x.Description)
                .MaximumLength(512)
                .WithMessage("Description must not exceed 512 characters.");

            RuleFor(x => x.ProteinGrams)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Protein value cannot be negative.");

            RuleFor(x => x.CarbonGrams)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Carbon value cannot be negative.");

            RuleFor(x => x.FatGrams)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Fat value cannot be negative.");
        }
    }
}
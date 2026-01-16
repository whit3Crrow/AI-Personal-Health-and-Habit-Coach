using AIPersonalHealthAndHabitCoach.Application.Meals.Commands.CreateMeal;
using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Meals.Commands.CreateMeal
{
    public class CreateMealCommandValidator : AbstractValidator<CreateMealCommand>
    {
        public CreateMealCommandValidator()
        {
            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(200).WithMessage("Description must not exceed 200 characters.");

            RuleFor(v => v.ProteinGrams)
                .GreaterThanOrEqualTo(0).WithMessage("Protein value cannot be negative.");

            RuleFor(v => v.CarbonGrams)
                .GreaterThanOrEqualTo(0).WithMessage("Carbohydrates value cannot be negative.");

            RuleFor(v => v.FatGrams)
                .GreaterThanOrEqualTo(0).WithMessage("Fat value cannot be negative.");
        }
    }
}
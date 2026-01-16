using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Meal.Commands.UpdateMeal
{
    public class UpdateMealCommandValidator : AbstractValidator<UpdateMealCommand>
    {
        public UpdateMealCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Meal ID is required.");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(200).WithMessage("Description must not exceed 200 characters.");

            RuleFor(v => v.ProteinGrams)
                .GreaterThanOrEqualTo(0).WithMessage("Protein cannot be negative.");

            RuleFor(v => v.CarbonGrams)
                .GreaterThanOrEqualTo(0).WithMessage("Carbohydrates cannot be negative.");

            RuleFor(v => v.FatGrams)
                .GreaterThanOrEqualTo(0).WithMessage("Fat cannot be negative.");
        }
    }
}
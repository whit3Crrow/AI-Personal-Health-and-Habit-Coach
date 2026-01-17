using FluentValidation;

namespace AIPersonalHealthAndHabitCoach.Application.Meals.Commands.UpdateMeal
{
    public class UpdateMealCommandValidator : AbstractValidator<UpdateMealCommand>
    {
        public UpdateMealCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Meal ID cannot be empty.");

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
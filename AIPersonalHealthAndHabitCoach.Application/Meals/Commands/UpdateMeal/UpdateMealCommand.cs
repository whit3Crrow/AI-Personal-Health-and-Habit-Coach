using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Meals.Commands.UpdateMeal
{
    public class UpdateMealCommand : IRequest
    {
        public Guid Id { get; set; }
        public required string Description { get; set; }
        public required decimal ProteinGrams { get; set; }
        public required decimal CarbonGrams { get; set; }
        public required decimal FatGrams { get; set; }
        public required DateTime StartDate { get; set; }
    }
}
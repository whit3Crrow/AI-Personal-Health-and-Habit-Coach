using AIPersonalHealthAndHabitCoach.Domain.Enums;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Meals.Commands.CreateMeal
{
    public class CreateMealCommand : IRequest<Guid>
    {
        public required string Description { get; set; }
        public required decimal ProteinGrams { get; set; }
        public required decimal CarbonGrams { get; set; } 
        public required decimal FatGrams { get; set; }
    }
}
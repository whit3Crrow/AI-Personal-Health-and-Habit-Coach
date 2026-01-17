using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Entities;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Meals.Commands.CreateMeal
{
    public class CreateMealCommandHandler : IRequestHandler<CreateMealCommand, Guid>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateMealCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Guid> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            var meal = new Meal
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                ProteinGrams = request.ProteinGrams,
                CarbonGrams = request.CarbonGrams,
                FatGrams = request.FatGrams,
                StartDateTimeUtc = request.StartDate
            };

            _applicationDbContext.Meals.Add(meal);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return meal.Id;
        }
    }
}
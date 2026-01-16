using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Entities; 
using AIPersonalHealthAndHabitCoach.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AIPersonalHealthAndHabitCoach.Application.Meal.Commands.UpdateMeal
{
    public class UpdateMealCommandHandler : IRequestHandler<UpdateMealCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateMealCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Handle(UpdateMealCommand request, CancellationToken cancellationToken)
        {
            var meal = await _applicationDbContext.Meals
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (meal == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Meal), request.Id.ToString());
            }

            meal.Description = request.Description;
            meal.ProteinGrams = request.ProteinGrams;
            meal.CarbonGrams = request.CarbonGrams;
            meal.FatGrams = request.FatGrams;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

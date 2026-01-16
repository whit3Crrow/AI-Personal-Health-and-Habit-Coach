using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Entities;
using MediatR;

namespace AIPersonalHealthAndHabitCoach.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Guid>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateActivityCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Guid> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = new AIPersonalHealthAndHabitCoach.Domain.Entities.Activity
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                CaloriesBurned = request.CaloriesBurned,
                ActivityType = request.ActivityType
            };

            _applicationDbContext.Activities.Add(activity);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return activity.Id;
        }
    }
}
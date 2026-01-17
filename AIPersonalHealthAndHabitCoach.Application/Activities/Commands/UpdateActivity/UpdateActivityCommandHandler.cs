using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Entities; 
using AIPersonalHealthAndHabitCoach.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore; 

namespace AIPersonalHealthAndHabitCoach.Application.Activities.Commands.UpdateActivity
{
    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateActivityCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = await _applicationDbContext.Activities
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (activity is null)
            {
                throw new NotFoundException(nameof(Activity), request.Id.ToString());
            }

            activity.Description = request.Description;
            activity.CaloriesBurned = request.CaloriesBurned;
            activity.ActivityType = request.ActivityType;
            activity.StartDateTimeUtc = request.StartDate;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

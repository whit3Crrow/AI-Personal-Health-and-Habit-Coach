using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Entities;
using AIPersonalHealthAndHabitCoach.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AIPersonalHealthAndHabitCoach.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateUserCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Users
                .FirstOrDefaultAsync(cancellationToken);

            if (user is null)
            {
                throw new NotFoundException(nameof(User), "initial");
            }
            
            user.WeightKilograms = request.WeightKilograms;
            user.HeightCentimeters = request.HeightCentimeters;
            user.Age = request.Age;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}

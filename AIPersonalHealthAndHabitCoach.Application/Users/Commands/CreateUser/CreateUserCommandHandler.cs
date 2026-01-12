using AIPersonalHealthAndHabitCoach.Application.Interfaces;
using AIPersonalHealthAndHabitCoach.Domain.Entities;
using AIPersonalHealthAndHabitCoach.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AIPersonalHealthAndHabitCoach.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateUserCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var isUserAlreadyCreated = await _applicationDbContext.Users
                .AnyAsync(cancellationToken);

            if (isUserAlreadyCreated)
            {
                throw new BadRequestException("User is already created.");
            }
            
            var user = new User
            {
                Id = Guid.NewGuid(),
                WeightKilograms = request.WeightKilograms,
                HeightCentimeters = request.HeightCentimeters,
                Age = request.Age
            };

            _applicationDbContext.Users.Add(user);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}

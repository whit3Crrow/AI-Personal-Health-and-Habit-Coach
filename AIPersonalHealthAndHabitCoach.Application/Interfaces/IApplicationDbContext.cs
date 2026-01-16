using Microsoft.EntityFrameworkCore;
using AIPersonalHealthAndHabitCoach.Domain.Entities;

namespace AIPersonalHealthAndHabitCoach.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Sleep> Sleeps { get; set; }
        DbSet<Activity> Activities { get; set; }
        DbSet<Domain.Entities.Meal> Meals { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

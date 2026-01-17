using AIPersonalHealthAndHabitCoach.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIPersonalHealthAndHabitCoach.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Metric> Metrics { get; set; }
        DbSet<Sleep> Sleeps { get; set; }
        DbSet<Activity> Activities { get; set; }
        DbSet<Meal> Meals { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

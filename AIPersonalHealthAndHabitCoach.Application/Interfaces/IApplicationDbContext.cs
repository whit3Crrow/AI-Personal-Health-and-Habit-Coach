using Microsoft.EntityFrameworkCore;
using AIPersonalHealthAndHabitCoach.Domain.Entities;

namespace AIPersonalHealthAndHabitCoach.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Sleep> Sleeps { get; }
        DbSet<Activity> Activities { get; }
        DbSet<Meal> Meals { get; }
        DbSet<User> Users { get; }
    }
}

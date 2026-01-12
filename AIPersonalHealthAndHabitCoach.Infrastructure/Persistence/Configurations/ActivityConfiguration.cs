using AIPersonalHealthAndHabitCoach.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIPersonalHealthAndHabitCoach.Infrastructure.Persistence.Configurations
{
    internal class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.Property(e => e.Description)
                .HasMaxLength(512)
                .IsRequired();

            builder.Property(e => e.CaloriesBurned)
                .IsRequired();

            builder.Property(e => e.ActivityType)
               .IsRequired();
        }
    }
}

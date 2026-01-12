using AIPersonalHealthAndHabitCoach.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIPersonalHealthAndHabitCoach.Infrastructure.Persistence.Configurations
{
    internal class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.StartDateTimeUtc)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(512)
                .IsRequired();

            builder.Property(e => e.CaloriesBurned)
                .IsRequired();

            builder.Property(e => e.Type)
               .IsRequired();
        }
    }
}

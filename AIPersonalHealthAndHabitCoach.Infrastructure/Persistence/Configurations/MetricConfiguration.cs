using AIPersonalHealthAndHabitCoach.Domain.Entities;
using AIPersonalHealthAndHabitCoach.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIPersonalHealthAndHabitCoach.Infrastructure.Persistence.Configurations
{
    internal class MetricConfiguration : IEntityTypeConfiguration<Metric>
    {
        public void Configure(EntityTypeBuilder<Metric> builder)
        {
            builder.ToTable("Metrics");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.StartDateTimeUtc)
                .IsRequired();

            builder.HasDiscriminator(e => e.Type)
                .HasValue<Sleep>(MetricType.Sleep)
                .HasValue<Activity>(MetricType.Activity)
                .HasValue<Meal>(MetricType.Meal);
        }
    }
}

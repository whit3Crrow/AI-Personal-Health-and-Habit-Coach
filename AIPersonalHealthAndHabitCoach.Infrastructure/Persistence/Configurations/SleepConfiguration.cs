using AIPersonalHealthAndHabitCoach.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIPersonalHealthAndHabitCoach.Infrastructure.Persistence.Configurations
{
    internal class SleepConfiguration : IEntityTypeConfiguration<Sleep>
    {
        public void Configure(EntityTypeBuilder<Sleep> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.StartDateTimeUtc)
                .IsRequired();

            builder.Property(e => e.DurationMinutes)
                .IsRequired();

            builder.Property(e => e.Quality)
                .IsRequired();
        }
    }
}

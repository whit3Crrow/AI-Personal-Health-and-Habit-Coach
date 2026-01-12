using AIPersonalHealthAndHabitCoach.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIPersonalHealthAndHabitCoach.Infrastructure.Persistence.Configurations
{
    internal class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.StartDateTimeUtc)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(512)
                .IsRequired();

            builder.Property(e => e.ProteinGrams)
                .IsRequired();

            builder.Property(e => e.CarbonGrams)
               .IsRequired();

            builder.Property(e => e.FatGrams)
               .IsRequired();
        }
    }
}

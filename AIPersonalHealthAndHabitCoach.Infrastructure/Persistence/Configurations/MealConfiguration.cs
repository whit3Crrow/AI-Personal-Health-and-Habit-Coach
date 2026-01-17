using AIPersonalHealthAndHabitCoach.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIPersonalHealthAndHabitCoach.Infrastructure.Persistence.Configurations
{
    internal class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.Property(e => e.Description)
                .HasMaxLength(512)
                .IsRequired();

            builder.Property(e => e.ProteinGrams)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.CarbonGrams)
                .HasPrecision(18, 2)
               .IsRequired();

            builder.Property(e => e.FatGrams)
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}

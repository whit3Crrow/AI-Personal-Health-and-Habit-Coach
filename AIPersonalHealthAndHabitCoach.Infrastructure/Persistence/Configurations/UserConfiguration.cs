using AIPersonalHealthAndHabitCoach.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIPersonalHealthAndHabitCoach.Infrastructure.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.WeightKilograms)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.HeightCentimeters)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.Age)
                .IsRequired();
        }
    }
}
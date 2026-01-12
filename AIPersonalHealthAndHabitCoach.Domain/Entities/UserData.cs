using System;

namespace AIPersonalHealthAndHabitCoach.Domain.Entities
{
    public class UserData
    {
        public Guid Id { get; set; }
        public decimal WeightKilograms { get; set; }
        public decimal HeightCentimeters { get; set; }
        public int Age { get; set; }
    }
}
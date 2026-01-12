namespace AIPersonalHealthAndHabitCoach.Domain.Entities
{
    public class Meal : Metrics
    {
        public string Description { get; set; } = string.Empty;
        public decimal ProteinGrams { get; set; }
        public decimal CarbonGrams { get; set; }
        public decimal FatGrams { get; set; }
    }
}
using System.Collections.Generic; // Pamiętaj o tym usingu dla List<>

namespace AIPersonalHealthAndHabitCoach.Domain.Entities
{
    public class Meal : Metric
    {
        public string Description { get; set; } = string.Empty;
        public decimal ProteinGrams { get; set; }
        public decimal CarbonGrams { get; set; }
        public decimal FatGrams { get; set; }
        public override List<string> GetTags()
        {
            var tags = new List<string>();

            if (ProteinGrams >= 25)
            {
                tags.Add("High Protein");
            }

            if (CarbonGrams < 20)
            {
                tags.Add("Low Carb");
            }

            else if (CarbonGrams > 80)
            {
                tags.Add("High Energy");
            }

            if (ProteinGrams > 20 &&
                CarbonGrams >= 30 && CarbonGrams <= 90 &&
                FatGrams <= 35)
            {
                tags.Add("Well Balanced");
            }

            if (tags.Count == 0)
            {
                tags.Add("Snack");
            }

            return tags;
        }
    }
}
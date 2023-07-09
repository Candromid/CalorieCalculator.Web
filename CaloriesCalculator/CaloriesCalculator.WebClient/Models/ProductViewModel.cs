using System.Diagnostics.CodeAnalysis;

namespace CaloriesCalculator.WebClient.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Proteins { get; set; }
        public decimal Fats { get; set; }
        public decimal Carbohydrates { get; set; }
    }
}

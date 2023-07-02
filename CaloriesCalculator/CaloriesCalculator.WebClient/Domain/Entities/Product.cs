using System.Diagnostics.CodeAnalysis;

namespace CaloriesCalculator.WebClient.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }


        public decimal Proteins { get; set; }
        public decimal Fats { get; set; }
        public decimal Carbohydrates { get; set; }
    }
}

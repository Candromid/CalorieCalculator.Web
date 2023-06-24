namespace CaloriesCalculator.WebClient.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public float Proteins { get; set; }
        public float Fats { get; set; }
        public float Carbohydrates { get; set; }
    }
}

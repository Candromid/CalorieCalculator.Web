namespace CaloriesCalculator.WebClient.Models
{
    internal class CalcCalorieResultViewModel
    {
        public decimal TotalProteins { get; set; }
        public decimal TotalFats { get; set; }
        public decimal TotalCarbohydrates { get; set; }
        public decimal TotalCalories { get; set; }
        public decimal CaloriesPer100g { get; set; }
    }
}
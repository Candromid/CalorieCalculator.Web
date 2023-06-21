﻿namespace CaloriesCalculator.WebClient.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float ProductProteins { get; set; }
        public float ProductFats { get; set; }
        public float ProductCarbohydrates { get; set; }
    }
}
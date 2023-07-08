using CaloriesCalculator.WebClient.Domain;
using CaloriesCalculator.WebClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CaloriesCalculator.WebClient.Controllers
{
    public class CalcCalorieController : Controller
    {
        private readonly DatabaseContext _context;

        public CalcCalorieController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchProducts(string query)
        {
            var products = _context.Products
                .Where(p => p.Name.Contains(query))
                .Select(p => new Product
                {
                    Name = p.Name
                })
                .ToList();

            return Json(products);
        }

        [HttpPost]
        public IActionResult CalculateCalories(string product)
        {
            var selectedProduct = _context.Products.FirstOrDefault(p => p.Name == product);

            if (selectedProduct == null)
            {
                return BadRequest("Продукт не найден.");
            }

            // Расчет калорий на основе выбранного продукта и веса 100 грамм
            decimal calories = (selectedProduct.Proteins + selectedProduct.Fats + selectedProduct.Carbohydrates) / 100;

            return Json(new { calories });
        }
    }
}

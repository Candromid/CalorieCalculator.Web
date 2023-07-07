using CaloriesCalculator.WebClient.Domain;
using CaloriesCalculator.WebClient.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CaloriesCalculator.WebClient.Controllers
{
    public class CalcCalorieController : Controller
    {
        private readonly DatabaseContext _context;

        public CalcCalorieController(DatabaseContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult CalculateCalories(int productId)
        {
            // Найти продукт по его идентификатору в БД
            var product = _context.Products.Find(productId);

            if (product == null)
            {
                return BadRequest("Продукт не найден.");
            }

            // Расчет калорий на основе выбранного продукта и веса 100 грамм
            decimal calories = (product.Proteins + product.Fats + product.Carbohydrates) / 100;

            return Ok(new { calories });
        }
    }
}

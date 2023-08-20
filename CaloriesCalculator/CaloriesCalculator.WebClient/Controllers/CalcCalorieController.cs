using CaloriesCalculator.Infrastructure;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchProducts(string term)
        {
            var products = _context.Products
                .Where(p => p.Name.Contains(term))
                .Select(p => new {
                    label = p.Name,
                    value = p.Name,
                    proteins = p.Proteins,
                    fats = p.Fats,
                    carbohydrates = p.Carbohydrates
                })
                .ToList();

            return Json(products);
        }

    }

}

using CaloriesCalculator.WebClient.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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

        public IActionResult SearchProducts(string term)
        {
            var products = _context.Products
                .Where(p => p.Name.StartsWith(term))
                .Select(p => new { p.Id, p.Name })
                .ToList();

            return Json(products);
        }

        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            return Json(product);
        }
    }

}

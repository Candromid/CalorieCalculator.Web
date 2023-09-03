using CaloriesCalculator.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CaloriesCalculator.WebClient.Controllers
{
    public class CalcCalorieController : Controller
    {
        private readonly ProductRepository _productRepository;

        public CalcCalorieController(ProductRepository productRepository)
        {

            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchProducts(string term)
        {
            var products = _productRepository.Search(term).Select(p => new
            {
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

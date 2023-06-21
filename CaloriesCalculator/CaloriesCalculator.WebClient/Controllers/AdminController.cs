using CaloriesCalculator.WebClient.Domain;
using CaloriesCalculator.WebClient.Models;
using CaloriesCalculator.WebClient.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CaloriesCalculator.WebClient.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin() 
        {
            return View();
        }

        private readonly DatabaseContext _context;

        public AdminController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddProducts(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newProduct = new Products
                {
                    ID = model.ProductId,
                    Name = model.ProductName,
                    Proteins = model.ProductProteins,
                    Fats = model.ProductFats,
                    Carbohydrates = model.ProductCarbohydrates
                };

                var t = _context.Products.ToList();

                //_context.Products.Add(newProduct);
                //_context.SaveChanges();



                return RedirectToAction("Admin", "Admin");
            }
            
            
            
            return View();
        }
    }
}

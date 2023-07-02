using CaloriesCalculator.WebClient.Domain;
using CaloriesCalculator.WebClient.Models;
using CaloriesCalculator.WebClient.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CaloriesCalculator.WebClient.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var filteredProducts = _context.Products.Where(p => p.Name.Contains(search)).ToList();
                return View(filteredProducts);
            }
            else
            {
                var allProducts = _context.Products.ToList();
                return View(allProducts);
            }
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
                var newProduct = new Product
                {
                    Name = model.Name,
                    Proteins = model.Proteins,
                    Fats = model.Fats,
                    Carbohydrates = model.Carbohydrates
                };

                _context.Products.Add(newProduct);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Продукт успешно добавлен.";


                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

      
        [HttpPost]
        public IActionResult DeleteProduct(Product product)
        {
            if (product != null)
            {
                try
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();

                    TempData["SuccessMessage"] = "Продукт успешно удалён.";

                    return RedirectToAction("Index", "Admin");
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = "Ошибка при удалении продукта: " + ex.Message;
                    return View("Error");
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Продукт не найден!";
                return View("Error");
            }

        }


        [HttpPost]
        public IActionResult EditProduct(int id, string newName, decimal newProteins, decimal newFats, decimal newCarbohydrates)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                ViewData["ErrorMessage"] = "Продукт не найден!";
                return View("Error");
            }

            try
            {
                product.Name = newName;
                product.Proteins = newProteins;
                product.Fats = newFats;
                product.Carbohydrates = newCarbohydrates;
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Продукт успешно изменен.";
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "Ошибка при изменении продукта: " + ex.Message;
                return View("Error");
            }
        }

    }
}

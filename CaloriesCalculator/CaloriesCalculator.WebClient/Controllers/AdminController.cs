using Microsoft.AspNetCore.Mvc;

namespace CaloriesCalculator.WebClient.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin() 
        {
            return View();
        }
    }
}

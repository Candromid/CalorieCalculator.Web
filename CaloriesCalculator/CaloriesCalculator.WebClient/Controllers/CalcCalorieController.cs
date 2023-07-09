using Microsoft.AspNetCore.Mvc;

namespace CaloriesCalculator.WebClient.Controllers
{
    public class CalcCalorieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

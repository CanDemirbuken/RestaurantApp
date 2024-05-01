using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace RestaurantMVC.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

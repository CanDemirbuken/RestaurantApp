using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var about = _aboutService.GetAllAsync().Result.OrderByDescending(x => x.CreatedDate).Take(1).ToList();
            var aboutViewModel = about.Select(x => new AboutViewModel
            {
                Title = x.Title,
                Description = x.Description,
            });

            return View(aboutViewModel);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Entitites;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            var about = await _aboutService.GetAllAsync();
            var aboutViewModel = about.Select(x => new AboutViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            });

            return View(aboutViewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AboutCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var about = new About
            {
                Title = model.Title,
                Description = model.Description,
            };

            await _aboutService.AddAsync(about);

            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var about = await _aboutService.GetByIdAsync(id);
            if (about == null)
            {
                return View();
            }

            var aboutViewModel = new AboutUpdateViewModel
            {
                Id = about.Id,
                Title = about.Title,
                Description = about.Description
            };

            return View(aboutViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AboutUpdateViewModel model)
        {
            var about = await _aboutService.GetByIdAsync(model.Id);
            if (about == null)
            {
                return View();
            }

            about.Title = model.Title;
            about.Description = model.Description;

            _aboutService.Update(about);

            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var about = await _aboutService.GetByIdAsync(id);
            if (about == null)
            {
                return View();
            }

            _aboutService.Delete(about);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
    }
}

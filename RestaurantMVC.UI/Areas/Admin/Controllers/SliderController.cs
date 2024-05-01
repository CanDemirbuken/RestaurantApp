using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using RestaurantMVC.BusinessLayer.Services;
using RestaurantMVC.Core.Entitites;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IFileProvider _fileProvider;

        public SliderController(ISliderService sliderService, IFileProvider fileProvider)
        {
            _sliderService = sliderService;
            _fileProvider = fileProvider;
        }

        public async Task<IActionResult> Index()
        {
            var slider = await _sliderService.GetAllAsync();
            var sliderViewModel = slider.Select(x => new SliderViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ButtonText = x.ButtonText,
                ButtonLink = x.ButtonLink,
                ImageURL = x.ImageURL
            });

            return View(sliderViewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SliderCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var slider = new Slider
            {
                Title = model.Title,
                Description = model.Description,
                ButtonText = model.ButtonText,
                ButtonLink = model.ButtonLink,
            };

            var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
            var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(model.ImageURL!.FileName)}";
            var newPicturePath = Path.Combine(wwwrootFolder.First(x => x.Name == "upload_img").PhysicalPath!, randomFileName);

            using var stream = new FileStream(newPicturePath, FileMode.Create);
            await model.ImageURL.CopyToAsync(stream);

            slider.ImageURL = randomFileName;

            await _sliderService.AddAsync(slider);
            return RedirectToAction("Index", "Slider", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var slider = await _sliderService.GetByIdAsync(id);
            if (slider == null)
            {
                return View();
            }

            var SliderViewModel = new SliderViewModel
            {
                Id = slider.Id,
                Title = slider.Title,
                Description = slider.Description,
                ButtonText = slider.ButtonText,
                ButtonLink = slider.ButtonLink,
                ImageURL = slider.ImageURL
            };

            return View(SliderViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Update(SliderUpdateViewModel model)
        {
            var slider = await _sliderService.GetByIdAsync(model.Id);
            if (slider == null)
            {
                return View();
            }

            if (model.ImageURL != null)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(model.ImageURL!.FileName)}";
                var newPicturePath = Path.Combine(wwwrootFolder.First(x => x.Name == "upload_img").PhysicalPath!, randomFileName);

                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await model.ImageURL.CopyToAsync(stream);
                slider.ImageURL = randomFileName;
            }

            slider.Title = model.Title;
            slider.Description = model.Description;
            slider.ButtonText = model.ButtonText;
            slider.ButtonLink = model.ButtonLink;

            _sliderService.Update(slider);
            return RedirectToAction("Index", "Slider", new { area = "Admin" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var slider = await _sliderService.GetByIdAsync(id);
            if (slider == null)
            {
                return View();
            }

            _sliderService.Delete(slider);
            return RedirectToAction("Index", "Slider", new { area = "Admin" });
        }
    }
}

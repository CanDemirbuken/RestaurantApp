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
    public class ServiceController : Controller
    {
        private readonly IServicesService _servicesService;
        private readonly IFileProvider _fileProvider;

        public ServiceController(IServicesService servicesService, IFileProvider fileProvider)
        {
            _servicesService = servicesService;
            _fileProvider = fileProvider;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _servicesService.GetAllAsync();
            var serviceViewModels = services.Select(x => new ServiceViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            });

            return View(serviceViewModels);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ServiceCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var service = new Service
            {
                Title = model.Title,
                Description = model.Description,
            };

            var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
            var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(model.Logo!.FileName)}";
            var newPicturePath = Path.Combine(wwwrootFolder.First(x => x.Name == "upload_img").PhysicalPath!, randomFileName);

            using var stream = new FileStream(newPicturePath, FileMode.Create);
            await model.Logo.CopyToAsync(stream);

            service.Logo = randomFileName;

            await _servicesService.AddAsync(service);
            return RedirectToAction("Index", "Service", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var service = await _servicesService.GetByIdAsync(id);
            if (service == null)
            {
                return View();
            }

            var serviceViewModel = new ServiceViewModel
            {
                Id = service.Id,
                Title = service.Title,
                Description = service.Description,
                Logo = service.Logo
            };

            return View(serviceViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Update(ServiceUpdateViewModel model)
        {
            var service = await _servicesService.GetByIdAsync(model.Id);
            if (service == null)
            {
                return View();
            }
            
            if (model.Logo != null)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(model.Logo!.FileName)}";
                var newPicturePath = Path.Combine(wwwrootFolder.First(x => x.Name == "upload_img").PhysicalPath!, randomFileName);

                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await model.Logo.CopyToAsync(stream);
                service.Logo = randomFileName;
            }

            service.Title = model.Title;
            service.Description = model.Description;

            _servicesService.Update(service);
            return RedirectToAction("Index", "Service", new { area = "Admin" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var service = await _servicesService.GetByIdAsync(id);
            if (service == null)
            {
                return View();
            }

            _servicesService.Delete(service);
            return RedirectToAction("Index", "Service", new { area = "Admin" });
        }
    }
}

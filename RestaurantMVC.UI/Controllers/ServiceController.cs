using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServicesService _servicesService;

        public ServiceController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _servicesService.GetAllAsync();
            var servicesViewModel = services.Select(x => new ServiceViewModel
            {
                Title = x.Title,
                Description = x.Description,
                Logo = x.Logo
            }).ToList();

            return View(servicesViewModel);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Helpers;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.ViewComponents
{
    public class ServiceViewComponent : ViewComponent
    {
        private readonly IServicesService _service;

        public ServiceViewComponent(IServicesService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
            var services = _service.GetAllAsync();
            var serviceViewModel = services.Result.Select(x => new ServiceViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = HtmlHelper.StripHtml(x.Description),
                Logo = x.Logo
            }).OrderByDescending(x => x.Id).Take(4).ToList();

            return View(serviceViewModel);
        }
    }
}

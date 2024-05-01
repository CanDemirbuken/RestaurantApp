using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Helpers;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public AboutViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IViewComponentResult Invoke()
        {
            var about = _aboutService.GetAllAsync();
            var aboutViewModel = about.Result.Select(x => new AboutViewModel
            {
                Title = x.Title,
                Description = HtmlHelper.StripHtml(x.Description),
            }).OrderByDescending(x => x.Id).Take(1).ToList();

            return View(aboutViewModel);
        }
    }
}

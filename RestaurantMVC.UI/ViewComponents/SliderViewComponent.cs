using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Helpers;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISliderService _sliderService;

        public SliderViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IViewComponentResult Invoke()
        {
            var slider = _sliderService.GetAllAsync();
            var sliderViewModel = slider.Result.Select(x => new SliderViewModel
            {
                Title = x.Title,
                Description = HtmlHelper.StripHtml(x.Description),
                ImageURL = x.ImageURL,
                ButtonText = x.ButtonText,
                ButtonLink = x.ButtonLink,
            }).OrderByDescending(x => x.Id).Take(1).ToList();

            return View(sliderViewModel);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Helpers;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.Controllers
{
    public class LayoutController : Controller
    {
        private readonly ISliderService _sliderService;

        public LayoutController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult SpinnerPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult ScriptsPartial()
        {
            return PartialView();
        }
    }
}

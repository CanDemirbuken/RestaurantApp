using Microsoft.AspNetCore.Mvc;

namespace RestaurantMVC.UI.ViewComponents
{
    public class ReservationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace RestaurantMVC.UI.Areas.Admin.Controllers
{
    public class LayoutController : Controller
    {
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult SideHeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult SideMenuPartial()
        {
            return PartialView();
        }

        public PartialViewResult HeaderPartial()
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

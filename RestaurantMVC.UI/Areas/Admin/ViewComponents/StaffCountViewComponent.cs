using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Services;

namespace RestaurantMVC.UI.Areas.Admin.ViewComponents
{
    public class StaffCountViewComponent : ViewComponent
    {
        private readonly IStaffService _staffService;

        public StaffCountViewComponent(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public IViewComponentResult Invoke()
        {
            var staff = _staffService.GetAllAsync();
            ViewBag.Staff = staff.Result.Count();
            return View();
        }
    }
}

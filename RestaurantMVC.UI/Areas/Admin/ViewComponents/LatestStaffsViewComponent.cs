using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.Areas.Admin.ViewComponents
{
    public class LatestStaffsViewComponent : ViewComponent
    {
        private readonly IStaffService _staffService;

        public LatestStaffsViewComponent(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public IViewComponentResult Invoke()
        {
            var staff = _staffService.GetAllAsync().Result.OrderByDescending(x => x.CreatedDate).Take(5).ToList();
            var staffViewModel = staff.Select(x => new StaffVCViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Title = x.Title
            });

            return View(staffViewModel);
        }
    }
}

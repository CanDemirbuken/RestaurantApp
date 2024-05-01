using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.ViewComponents
{
    public class StaffViewComponent : ViewComponent
    {
        private readonly IStaffService _staffService;

        public StaffViewComponent(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public IViewComponentResult Invoke()
        {
            var staff = _staffService.GetAllAsync();
            var staffViewModel = staff.Result.Select(x => new StaffViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Title = x.Title,
                ImageURL = x.ImageURL,
                SocialMedia1 = x.SocialMedia1,
                SocialMedia2 = x.SocialMedia2,
                SocialMedia3 = x.SocialMedia3
            }).OrderByDescending(x => x.Id).Take(4).ToList();

            return View(staffViewModel);
        }
    }
}

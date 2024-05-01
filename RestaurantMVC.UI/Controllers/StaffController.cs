using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public async Task<IActionResult> Index()
        {
            var staff = await _staffService.GetAllAsync();
            var staffViewModel = staff.Select(x => new StaffViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Title = x.Title,
                ImageURL = x.ImageURL,
                SocialMedia1 = x.SocialMedia1,
                SocialMedia2 = x.SocialMedia2,
                SocialMedia3 = x.SocialMedia3,
            }).ToList();

            return View(staffViewModel);
        }
    }
}

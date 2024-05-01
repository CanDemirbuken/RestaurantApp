using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.BusinessLayer.Services;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> Index()
        {
            var testimonial = await _testimonialService.GetAllAsync();
            var testimonialViewModel = testimonial.Select(x => new TestimonialViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Title = x.Title,
                Comment = x.Comment
            });

            return View(testimonialViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var testimonial = await _testimonialService.GetByIdAsync(id);
            if (testimonial == null)
            {
                return View();
            }

            _testimonialService.Delete(testimonial);
            return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
        }
    }
}

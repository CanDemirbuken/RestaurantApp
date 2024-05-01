using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.ViewComponents
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialViewComponent(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var testimonial = _testimonialService.GetAllAsync();
            var testimonialViewModel = testimonial.Result.Select(x => new TestimonialViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Title = x.Title,
                Comment = x.Comment
            }).OrderByDescending(x => x.Id).Take(6).ToList();

            return View(testimonialViewModel);
        }
    }
}

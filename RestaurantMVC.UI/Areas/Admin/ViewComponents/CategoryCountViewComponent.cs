using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Services;

namespace RestaurantMVC.UI.Areas.Admin.ViewComponents
{
    public class CategoryCountViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryCountViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var category = _categoryService.GetAllAsync();
            ViewBag.Category = category.Result.Count();
            return View();
        }
    }
}

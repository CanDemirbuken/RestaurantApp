using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.BusinessLayer.Services;
using RestaurantMVC.Core.Entitites;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;
using System.Security.Policy;

namespace RestaurantMVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var category = await _categoryService.GetAllAsync();
            var categoryViewModel = category.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return View(categoryViewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var category = new Category
            {
                Name = model.Name
            };

            await _categoryService.AddAsync(category);

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                ModelState.AddModelError(string.Empty, "Kategori bulunamadı.");
                return View();
            }

            var categoryViewModel = new CategoryUpdateViewModel
            {
                Id = category.Id,
                Name = category.Name
            };

            return View(categoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateViewModel model)
        {
            var category = await _categoryService.GetByIdAsync(model.Id);
            if (category == null)
            {
                ModelState.AddModelError(string.Empty, "Kategori bulunamadı.");
                return View();
            }

            category.Name = model.Name;

            _categoryService.Update(category);

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                ModelState.AddModelError(string.Empty, "Kategori bulunamadı.");
                return View();
            }

            _categoryService.Delete(category);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}

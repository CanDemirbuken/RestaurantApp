using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Helpers;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;
using X.PagedList;

namespace RestaurantMVC.UI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IProductService _productService;

        public MenuController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            var products = await _productService.GetProductsWithCategory();
            var productViewModel = products.Select(x => new ProductViewModel
            {
                Name = x.Name,
                Description = HtmlHelper.StripHtml(x.Description),
                Price = x.Price,
                ImageURL = x.ImageURL,
                CategoryId = x.CategoryId,
            }).ToPagedList(page, pageSize);

            return View(productViewModel);
        }

    }
}

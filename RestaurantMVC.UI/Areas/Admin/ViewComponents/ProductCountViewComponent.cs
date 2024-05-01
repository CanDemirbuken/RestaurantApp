using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Services;

namespace RestaurantMVC.UI.Areas.Admin.ViewComponents
{
    public class ProductCountViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public ProductCountViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productService.GetAll();
            ViewBag.Products = products.Count();
            return View();
        }
    }
}

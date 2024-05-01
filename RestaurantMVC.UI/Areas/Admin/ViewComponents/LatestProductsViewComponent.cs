using Microsoft.AspNetCore.Mvc;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;

namespace RestaurantMVC.UI.Areas.Admin.ViewComponents
{
    public class LatestProductsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public LatestProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productService.GetAll().OrderByDescending(x => x.CreatedDate).Take(5).ToList();
            var productViewModel = products.Select(x => new ProductVCViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedDate
            });

            return View(productViewModel);
        }
    }
}

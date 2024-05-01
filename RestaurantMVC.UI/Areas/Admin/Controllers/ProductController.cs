using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using RestaurantMVC.Core.Entitites;
using RestaurantMVC.Core.Services;
using RestaurantMVC.UI.Areas.Admin.ViewModels;
using X.PagedList;

namespace RestaurantMVC.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IFileProvider _fileProvider;

        public ProductController(IProductService productService, ICategoryService categoryService, IFileProvider fileProvider)
        {
            _productService = productService;
            _categoryService = categoryService;
            _fileProvider = fileProvider;
        }

        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var products = _productService.GetAll();
            var productViewModelList = products.Select(x => new RestaurantMVC.UI.Areas.Admin.ViewModels.ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageURL = x.ImageURL,
                Price = x.Price
            });
            var paginatedList = productViewModelList.ToPagedList(page, pageSize);
            return View(paginatedList);
        }


        public async Task<IActionResult> Add()
        {
            var category = await _categoryService.GetAllAsync();
            ViewBag.Categories = category.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId
            };

            var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
            var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(model.ImageURL!.FileName)}";
            var newPicturePath = Path.Combine(wwwrootFolder.First(x => x.Name == "upload_img").PhysicalPath!, randomFileName);

            using var stream = new FileStream(newPicturePath, FileMode.Create);
            await model.ImageURL.CopyToAsync(stream);

            product.ImageURL = randomFileName;

            await _productService.AddAsync(product);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                ModelState.AddModelError(string.Empty, "Aranan ürün bulunamadı.");
                return View();
            }

            var category = await _categoryService.GetAllAsync();
            ViewBag.Categories = category.ToList();


            var productViewModel = new RestaurantMVC.UI.Areas.Admin.ViewModels.ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ImageURL = product.ImageURL
            };

            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateViewModel model)
        {
            var product = await _productService.GetByIdAsync(model.Id);
            if (product == null)
            {
                return View();
            }

            if (model.ImageURL != null)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(model.ImageURL!.FileName)}";
                var newPicturePath = Path.Combine(wwwrootFolder.First(x => x.Name == "upload_img").PhysicalPath!, randomFileName);

                using var stream = new FileStream(newPicturePath, FileMode.Create);
                await model.ImageURL.CopyToAsync(stream);
                product.ImageURL = randomFileName;
            }

            product.Id = model.Id;
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;

            _productService.Update(product);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                ModelState.AddModelError(string.Empty, "Aranan ürün bulunamadı.");
                return View();
            }

            _productService.Delete(product);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
    }
}

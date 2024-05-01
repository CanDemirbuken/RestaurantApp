using RestaurantMVC.Core.Entitites;
using RestaurantMVC.Core.Repositories;
using RestaurantMVC.Core.Services;
using RestaurantMVC.Core.UnitOfWorks;

namespace RestaurantMVC.BusinessLayer.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll().ToList();
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductsWithCategory();
            return products;
        }
    }
}

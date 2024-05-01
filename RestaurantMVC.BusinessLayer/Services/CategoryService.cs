using RestaurantMVC.Core.Entitites;
using RestaurantMVC.Core.Repositories;
using RestaurantMVC.Core.Services;
using RestaurantMVC.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMVC.BusinessLayer.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> GetCategoryByIdWithProducts(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdWithProducts(id);
            return category;
        }
    }
}

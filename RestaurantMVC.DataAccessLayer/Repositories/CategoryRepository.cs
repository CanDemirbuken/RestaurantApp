using Microsoft.EntityFrameworkCore;
using RestaurantMVC.Core.Entitites;
using RestaurantMVC.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMVC.DataAccessLayer.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryByIdWithProducts(int id)
        {
            return await _context.Categories.Include(c => c.Products).Where(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}

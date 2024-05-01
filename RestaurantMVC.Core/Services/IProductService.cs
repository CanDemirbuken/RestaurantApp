using RestaurantMVC.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMVC.Core.Services
{
    public interface IProductService : IService<Product>
    {
        List<Product> GetAll();
        Task<List<Product>> GetProductsWithCategory();
    }
}

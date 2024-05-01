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
    public class TestimonialService : Service<Testimonial>, ITestimonialService
    {
        public TestimonialService(IGenericRepository<Testimonial> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}

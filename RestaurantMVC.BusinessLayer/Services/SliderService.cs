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
    public class SliderService : Service<Slider>, ISliderService
    {
        public SliderService(IGenericRepository<Slider> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}

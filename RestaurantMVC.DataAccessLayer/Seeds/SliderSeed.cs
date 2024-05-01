using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantMVC.Core.Entitites;
using System.Collections.Generic;

namespace RestaurantMVC.Core.Entities
{
    public class SliderSeed : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasData(
                new Slider
                {
                    Id = 1,
                    Title = "Lezzet Dolu Tatlar",
                    Description = "En taze ve lezzetli malzemelerle hazırlanmış yemeklerimizi keşfedin.",
                    ButtonText = "Menüyü İncele",
                    ButtonLink = "/menu",
                    ImageURL = "lezzetli-yemekler.jpg"
                }
            );
        }
    }
}

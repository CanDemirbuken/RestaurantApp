// CategorySeed.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantMVC.Core.Entities;
using RestaurantMVC.Core.Entitites;

namespace RestaurantMVC.Core.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Et Yemekleri"
                },
                new Category
                {
                    Id = 2,
                    Name = "İtalyan Mutfağı"
                },
                new Category
                {
                    Id = 3,
                    Name = "Başlangıçlar"
                }
            );
        }
    }
}

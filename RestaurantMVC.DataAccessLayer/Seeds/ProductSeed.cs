using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantMVC.Core.Entitites;
using System.Collections.Generic;

namespace RestaurantMVC.Core.Entities
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Köfte",
                    Description = "Et ile hazırlanan nefis bir yemek.",
                    Price = 25.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "İskender",
                    Description = "Yoğurt ve etin muhteşem uyumu.",
                    Price = 30.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Lahmacun",
                    Description = "İncecik hamurun üzerinde lezzet şöleni.",
                    Price = 10.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    Name = "Adana Kebap",
                    Description = "Acı sevenlerin tercihi.",
                    Price = 27.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 5,
                    Name = "Pilav Üstü Döner",
                    Description = "Pirinç pilavının üzerinde tavuk veya et döner.",
                    Price = 20.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 6,
                    Name = "Pizza",
                    Description = "Fırında pişmiş, üzerinde enfes soslarla hazırlanmış pizza.",
                    Price = 22.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 7,
                    Name = "Makarna",
                    Description = "İtalyan mutfağının vazgeçilmezi makarna.",
                    Price = 18.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 8,
                    Name = "Risotto",
                    Description = "İtalyan usulü pirinç pilavı.",
                    Price = 24.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 9,
                    Name = "Calzone",
                    Description = "Kenarlarından kapatılmış pizza çeşidi.",
                    Price = 26.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 10,
                    Name = "Lasagne",
                    Description = "Fırında pişirilmiş, soslarla harmanlanmış nefis makarna tabağı.",
                    Price = 28.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 11,
                    Name = "Çorba",
                    Description = "Çeşitli sebzeler ve etle hazırlanan sıcak bir başlangıç.",
                    Price = 8.99m,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 12,
                    Name = "Salata",
                    Description = "Taze yeşillikler ve çeşitli malzemelerle hazırlanan sağlıklı salata.",
                    Price = 12.99m,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 13,
                    Name = "Meze Tabağı",
                    Description = "Çeşitli mezelerin bir araya getirildiği lezzet şöleni.",
                    Price = 14.99m,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 14,
                    Name = "Tavuk Çevirme",
                    Description = "Özel soslarla marine edilmiş, döner olarak servis edilen tavuk.",
                    Price = 16.99m,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 15,
                    Name = "Kumpir",
                    Description = "Fırında pişirilmiş patatesin içi çeşitli malzemelerle doldurulmuş lezzet şöleni.",
                    Price = 17.99m,
                    CategoryId = 3
                }
            );
        }
    }
}

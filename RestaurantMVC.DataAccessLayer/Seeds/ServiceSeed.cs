using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantMVC.Core.Entitites;
using System.Collections.Generic;

namespace RestaurantMVC.Core.Entities
{
    public class ServiceSeed : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasData(
                new Service
                {
                    Id = 1,
                    Title = "Açık Büfe Kahvaltı",
                    Description = "Sabah kahvaltıları için zengin açık büfe seçenekleri.",
                    Logo = "kahvalti.jpg"
                },
                new Service
                {
                    Id = 2,
                    Title = "Öğle Yemeği Menüsü",
                    Description = "Günlük değişen öğle yemeği menüleri ile lezzet dolu molalar.",
                    Logo = "ogle-yemegi.jpg"
                },
                new Service
                {
                    Id = 3,
                    Title = "Akşam Yemeği",
                    Description = "Aile yemekleri, romantik akşam yemekleri ve daha fazlası.",
                    Logo = "aksam-yemegi.jpg"
                },
                new Service
                {
                    Id = 4,
                    Title = "Parti ve Etkinlikler",
                    Description = "Özel partiler ve etkinlikler için özel menü seçenekleri.",
                    Logo = "parti-etkinlik.jpg"
                },
                new Service
                {
                    Id = 5,
                    Title = "Catering Hizmetleri",
                    Description = "Özel davetler ve toplantılar için catering hizmetleri.",
                    Logo = "catering.jpg"
                }
            );
        }
    }
}

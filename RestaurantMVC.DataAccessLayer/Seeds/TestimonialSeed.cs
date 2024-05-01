using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantMVC.Core.Entitites;
using System.Collections.Generic;

namespace RestaurantMVC.Core.Entities
{
    public class TestimonialSeed : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.HasData(
                new Testimonial
                {
                    Id = 1,
                    FirstName = "Mehmet",
                    LastName = "Yılmaz",
                    Title = "Müşteri",
                    Comment = "Restoranınızda harika bir deneyim yaşadım. Yemekler çok lezzetliydi ve personel çok ilgiliydi. Kesinlikle tekrar geleceğim!"
                },
                new Testimonial
                {
                    Id = 2,
                    FirstName = "Ayşe",
                    LastName = "Kaya",
                    Title = "Müşteri",
                    Comment = "Yemekleriniz gerçekten muhteşem! Restoranınızın atmosferi de çok güzel. Herkese tavsiye ederim."
                },
                new Testimonial
                {
                    Id = 3,
                    FirstName = "Ahmet",
                    LastName = "Demir",
                    Title = "Müşteri",
                    Comment = "Personeliniz çok profesyonel ve hızlı hizmet veriyor. Yemekler de çok lezzetliydi. Tekrar gelmek için sabırsızlanıyorum!"
                },
                new Testimonial
                {
                    Id = 4,
                    FirstName = "Fatma",
                    LastName = "Kocabaş",
                    Title = "Müşteri",
                    Comment = "Restoranınızda geçirdiğimiz akşam çok keyifliydi. Yemekler harikaydı ve servis mükemmeldi. Teşekkürler!"
                },
                new Testimonial
                {
                    Id = 5,
                    FirstName = "İsmail",
                    LastName = "Aydın",
                    Title = "Müşteri",
                    Comment = "Restoranınızın ambiyansı gerçekten çok güzel. Yemekler de lezzetliydi. Burası favori restoranımız oldu!"
                },
                new Testimonial
                {
                    Id = 6,
                    FirstName = "Zeynep",
                    LastName = "Yıldırım",
                    Title = "Müşteri",
                    Comment = "Restoranınızda harika bir doğum günü partisi düzenledik. Herkes çok eğlendi ve yemeklerden çok memnun kaldı. Teşekkür ederiz!"
                },
                new Testimonial
                {
                    Id = 7,
                    FirstName = "Mustafa",
                    LastName = "Çelik",
                    Title = "Müşteri",
                    Comment = "Yemeklerinizin lezzeti dillere destan! Her biri birbirinden özel ve nefisti. Tebrikler!"
                },
                new Testimonial
                {
                    Id = 8,
                    FirstName = "Selin",
                    LastName = "Güngör",
                    Title = "Müşteri",
                    Comment = "Restoranınızda ailemle harika bir akşam geçirdik. Yemekler lezzetliydi ve personel çok ilgiliydi. Teşekkürler!"
                },
                new Testimonial
                {
                    Id = 9,
                    FirstName = "Yusuf",
                    LastName = "Kara",
                    Title = "Müşteri",
                    Comment = "Restoranınızın yemekleri gerçekten çok lezzetliydi. Tekrar gelmek için sabırsızlanıyorum!"
                },
                new Testimonial
                {
                    Id = 10,
                    FirstName = "Seda",
                    LastName = "Yılmaz",
                    Title = "Müşteri",
                    Comment = "Personeliniz çok samimi ve içten. Yemekleriniz de harika. Burası benim favori restoranım oldu!"
                }
            );
        }
    }
}

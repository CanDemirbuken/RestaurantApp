using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantMVC.Core.Entitites;
using System.Collections.Generic;

namespace RestaurantMVC.Core.Entities
{
    public class StaffSeed : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(
                new Staff
                {
                    Id = 1,
                    FirstName = "Ali",
                    LastName = "Şef",
                    Title = "Baş Aşçı",
                    ImageURL = "bas-asci.jpg",
                    SocialMedia1 = "https://www.instagram.com/basasci/",
                    SocialMedia2 = "https://www.twitter.com/basasci/",
                    SocialMedia3 = "https://www.facebook.com/basasci/"
                },
                new Staff
                {
                    Id = 2,
                    FirstName = "Ayşe",
                    LastName = "Şef",
                    Title = "Sous Şef",
                    ImageURL = "sous-sef.jpg",
                    SocialMedia1 = "https://www.instagram.com/soussef/",
                    SocialMedia2 = "https://www.twitter.com/soussef/",
                    SocialMedia3 = "https://www.facebook.com/soussef/"
                },
                new Staff
                {
                    Id = 3,
                    FirstName = "Mehmet",
                    LastName = "Şef",
                    Title = "Tatlı Şef",
                    ImageURL = "tatli-sef.jpg",
                    SocialMedia1 = "https://www.instagram.com/tatlisef/",
                    SocialMedia2 = "https://www.twitter.com/tatlisef/",
                    SocialMedia3 = "https://www.facebook.com/tatlisef/"
                },
                new Staff
                {
                    Id = 4,
                    FirstName = "Fatma",
                    LastName = "Şef",
                    Title = "Garson Şef",
                    ImageURL = "garson-sef.jpg",
                    SocialMedia1 = "https://www.instagram.com/garsonsef/",
                    SocialMedia2 = "https://www.twitter.com/garsonsef/",
                    SocialMedia3 = "https://www.facebook.com/garsonsef/"
                },
                new Staff
                {
                    Id = 5,
                    FirstName = "Ahmet",
                    LastName = "Şef",
                    Title = "Bar Şef",
                    ImageURL = "bar-sef.jpg",
                    SocialMedia1 = "https://www.instagram.com/barsef/",
                    SocialMedia2 = "https://www.twitter.com/barsef/",
                    SocialMedia3 = "https://www.facebook.com/barsef/"
                }
            );
        }
    }
}

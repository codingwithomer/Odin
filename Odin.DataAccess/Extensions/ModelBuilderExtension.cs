using Microsoft.EntityFrameworkCore;
using Odin.Data.Models;
using System.Collections.Generic;

namespace Odin.DataAccess.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Defining seed data for customers
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Ali",
                    LastName = "Pasaran",
                    TCIdentityNumber = "17459647263",
                    Email = "alibekir.pasaran@nomail.com",
                    Phone = "05445467893",
                    IsDeleted  = false
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Bekir",
                    LastName = "Terzi",
                    TCIdentityNumber = "83219547632",
                    Email = "bekir.terzi@nomail.com",
                    Phone = "05558254793",
                    IsDeleted  = false
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Mücella",
                    LastName = "Yapıcı",
                    TCIdentityNumber = "42356178469",
                    Email = "mucella.yapici@nomail.com",
                    Phone = "05042561782",
                    IsDeleted  = false
                },
                new Customer
                {
                    Id = 4,
                    FirstName = "Viktor",
                    LastName = "Panteleev",
                    TCIdentityNumber = "92473156214",
                    Email = "viktor.pasaran@nomail.com",
                    Phone = "05434587965",
                    IsDeleted  = false
                },
                new Customer
                {
                    Id = 5,
                    FirstName = "Jasar",
                    LastName = "Ahmedovski",
                    TCIdentityNumber = "96573145217",
                    Email = "jasar.ahmedovski@nomail.com",
                    Phone = "05321478214",
                    IsDeleted  = false
                },
            };
            #endregion

            #region Defining seed data for products
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "IRun",
                    Description = "Apple'ın gözdesi ayran",
                    Price = 15m,
                    IsDeleted  = false
                },
                new Product
                {
                    Id = 2,
                    Name = "Homo Deus",
                    Description = "Yarının Kısa Bir Tarihi",
                    Price = 30m,
                    IsDeleted  = false
                },
                new Product
                {
                    Id = 3,
                    Name = "Suç ve Ceza",
                    Description = "Dostoyevski",
                    Price = 27.5m,
                    IsDeleted  = false
                },
                new Product
                {
                   Id = 4,
                    Name = "IRun",
                    Description = "Apple'ın gözdesi ayran",
                    Price = 14.5m,
                    IsDeleted  = false
                },
                new Product
                {
                    Id = 5,
                    Name = "Dell",
                    Description = "G3 Laptop For Gamers",
                    Price = 14500m,
                    IsDeleted  = false
                },
            };
            #endregion

            modelBuilder.Entity<Customer>().HasData(customers);
            modelBuilder.Entity<Product>().HasData(products);


        }
    }
}

﻿using MextFullStack.Domain.Entities;

namespace MextFullStack.WebApi.Data
{
    public static class FakeDatabase
    {
        public static List<Product> Products;

        static FakeDatabase()
        {
            Products = new List<Product>
            {
                new Product
                {
                    Id = new Guid("5f0e63ea-a2c8-44b5-af52-1e9f76c4e0f7"),
                    Name = "iPhone 13 Pro",
                    Price = 999.99m,
                    Description = "The latest iPhone with advanced camera system.",
                    CreatedOn = DateTime.Now,
                    CreatedByUserId = "user1"
                },
                new Product
                {
                    Id = new Guid("c991369d-bb4b-44f6-80a7-d5dcb599df53"),
                    Name = "iPad Air",
                    Price = 599.99m,
                    Description = "Powerful and versatile iPad with a stunning display.",
                    CreatedOn = DateTime.Now,
                    CreatedByUserId = "user2"
                },
                new Product
                {
                    Id = new Guid("cb175342-cd87-4c72-bf1a-54b7f67c96a3"),
                    Name = "iPhone 12",
                    Price = 799.99m,
                    Description = "A great iPhone with a beautiful design.",
                    CreatedOn = DateTime.Now,
                    CreatedByUserId = "user1"
                },
                new Product
                {
                    Id = new Guid("b606c2bf-3cc5-4734-bca0-9fb4e26976e8"),
                    Name = "iPad Pro",
                    Price = 1099.99m,
                    Description = "The most advanced iPad with a large screen.",
                    CreatedOn = DateTime.Now,
                    CreatedByUserId = "user3"
                },
                new Product
                {
                    Id = new Guid("2743c1b1-7258-4901-a9fb-94b9a520b24b"),
                    Name = "iPhone SE",
                    Price = 399.99m,
                    Description = "A compact and affordable iPhone.",
                    CreatedOn = DateTime.Now,
                    CreatedByUserId = "user2"
                }
            };
        }
    }
}

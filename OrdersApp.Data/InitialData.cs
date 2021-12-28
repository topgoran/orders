using Microsoft.EntityFrameworkCore;
using OrdersApp.Data.DataAccess;
using OrdersApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp.Data
{
    public static class InitialData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Guid menu1Guid = Guid.NewGuid();
            Menu menu1 = new Menu()
            {
                Id = menu1Guid,
                Name = "Menu 1",
                Description = "This is a menu 1",
                CoverId = 1,
                ImageId = 1,
            };

            Guid menu2Guid = Guid.NewGuid();
            Menu menu2 = new Menu()
            {
                Id = menu2Guid,
                Name = "Menu 2",
                Description = "This is a menu 2",
                CoverId = 2,
                ImageId = 2,
            };

            modelBuilder.Entity<Menu>().HasData(
                menu1,
                menu2
            );

            Guid article1Guid = Guid.NewGuid();
            Article article1 = new Article()
            {
                Id = article1Guid,
                Name = "Article 1",
                Description = "This is article 1",
                Price = 30.5M,
                ImageId = 3,
                CoverId = 3
            };

            Guid article2Guid = Guid.NewGuid();
            Article article2 = new Article()
            {
                Id = article2Guid,
                Name = "Article 2",
                Description = "This is article 2",
                Price = 34.5M,
                ImageId = 4,
                CoverId = 4
            };

            modelBuilder.Entity<Article>().HasData(
                article1,
                article2
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuId = menu1Guid,
                    ArticleId = article1Guid
                },
                new MenuItem
                {
                    Id = Guid.NewGuid(),
                    MenuId = menu2Guid,
                    ArticleId = article2Guid
                }
            );

            Guid user1Guid = Guid.NewGuid();
            User user1 = new User()
            {
                Id = user1Guid,
                FirstName = "User 1",
                LastName = "User 1",
                PhoneNumber = "Phone number 1",
                Address = "Street 1",
                City = "City 1",
                State = "State 1",
            };

            Guid user2Guid = Guid.NewGuid();
            User user2 = new User()
            {
                Id = user2Guid,
                FirstName = "User 2",
                LastName = "User 2",
                PhoneNumber = "Phone number 2",
                Address = "Street 2",
                City = "City 2",
                State = "State 2",
            };

            modelBuilder.Entity<User>().HasData(
                user1,
                user2
            );

            Guid order1Guid = Guid.NewGuid();
            Order order1 = new Order()
            {
                Id = order1Guid,
                Date = DateTime.Today,
                Note = "Note 1",
                UserId = user1Guid
            };

            Guid order2Guid = Guid.NewGuid();
            Order order2 = new Order()
            {
                Id = order2Guid,
                Date = DateTime.Today,
                Note = "Note 2",
                UserId = user2Guid
            };

            modelBuilder.Entity<Order>().HasData(
                order1,
                order2
            );

            Guid orderItem1Guid = Guid.NewGuid();
            OrderItem orderItem1 = new OrderItem()
            {
                Id = orderItem1Guid,
                Quantity = 10,
                Price = 305,
                OrderId = order1Guid,
                ArticleId = article2Guid
            };

            Guid orderItem2Guid = Guid.NewGuid();
            OrderItem orderItem2 = new OrderItem()
            {
                Id = orderItem2Guid,
                Quantity = 10,
                Price = 345,
                OrderId = order2Guid,
                ArticleId = article2Guid
            };

            modelBuilder.Entity<OrderItem>().HasData(
                orderItem1,
                orderItem2
            );

        }
    }
}

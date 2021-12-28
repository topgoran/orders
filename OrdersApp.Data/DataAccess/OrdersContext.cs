using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrdersApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace OrdersApp.Data.DataAccess
{
    public class OrdersContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        IHttpContextAccessor httpContextAccessor;
        public OrdersContext(DbContextOptions<OrdersContext> options, IHttpContextAccessor httpContextAccessor) : base(options) {
            this.httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

    }
}

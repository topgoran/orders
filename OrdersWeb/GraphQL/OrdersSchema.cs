using System;
using GraphQL.Types;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrdersApp.Data.Models;
using OrdersWeb.Configuration;
using OrdersWeb.GraphQL.Types;
using OrdersWeb.Repository;
using OrdersWeb.Repository.Abstract;

namespace OrdersWeb.GraphQL
{
    public class OrdersSchema : Schema
    {
        public OrdersSchema(IServiceProvider provider, IMenuRepository menuRepository, IUserRepository userRepository, IMenuItemRepository menuItemRepository,
            IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IArticleRepository articleRepository, UserManager<User> userManager, IOptionsMonitor<JwtConfig> optionsMonitor,
            RegistrationRepository registrationRepository) : base(provider)
        {
            Query = new Query(menuRepository, userRepository, menuItemRepository, orderItemRepository, orderRepository, articleRepository);
            Mutation = new Mutation( userRepository, articleRepository, menuItemRepository, orderRepository, orderItemRepository, menuRepository, userManager, optionsMonitor, registrationRepository);
        }
    }
}

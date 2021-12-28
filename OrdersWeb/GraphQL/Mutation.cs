using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OrdersApp.Data.Models;
using OrdersWeb.Configuration;
using OrdersWeb.DTOs.Create;
using OrdersWeb.DTOs.Read;
using OrdersWeb.GraphQL.Types;
using OrdersWeb.GraphQL.Types.InputTypes;
using OrdersWeb.Repository;
using OrdersWeb.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWeb.GraphQL
{
    [EnableCors("CorsApiPolicy")]
    public class Mutation : ObjectGraphType
    {
        //CREATE MUTATIONS
        public Mutation(IUserRepository userRepository, IArticleRepository articleRepository, 
            IMenuItemRepository menuItemRepository, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IMenuRepository menuRepository,
            UserManager<User> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, RegistrationRepository registrationRepository) {

            Field<RegistrationResponseType>(
                "registerMember",
                arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }),
                resolve: context =>
                {
                    var user = context.GetArgument<UserCreateDto>("user");

                    var response = registrationRepository.registration(user, userManager, optionsMonitor, "Member");
                    return response;
                });

            Field<RegistrationResponseType>(
                "registerAdmin",
                arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }),
                resolve: context =>
                {
                    var user = context.GetArgument<UserCreateDto>("user");

                    var response = registrationRepository.registration(user, userManager, optionsMonitor, "Admin");
                    return response;
                });

            Field<UserType>(
                "loginUser",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<StringGraphType>{
                        Name = "username"
                    },
                    new QueryArgument<StringGraphType>{
                        Name = "password"
                    }
                }),
                resolve: context =>
                {
                    var userName = context.GetArgument<String>("username");
                    var password = context.GetArgument<String>("password");

                    var response = registrationRepository.LogIn(userManager, optionsMonitor, userName, password);

                    return response;
                });

            Field<UserType>(
                "createUser",
                arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    return userRepository.Create(user);
                });

            Field<ArticleType>(
                "createArticle",
                arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<ArticleInputType>> { Name = "article" }),
                resolve: context =>
                {
                    var article = context.GetArgument<Article>("article");
                    return articleRepository.Create(article);
                });

            Field<MenuItemType>(
                "createMenuItem",
                arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<MenuItemInputType>> { Name = "menuItem" }),
                resolve: context =>
                {
                    var menuItem = context.GetArgument<MenuItem>("menuItem");
                    return menuItemRepository.Create(menuItem);
                });

            Field<OrderType>(
                "createOrder",
                arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<OrderInputType>> { Name = "order" }),
                resolve: context =>
                {
                    var order = context.GetArgument<Order>("order");
                    return orderRepository.Create(order);
                });

            Field<OrderItemType>(
                "createOrderItem",
                arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<OrderItemInputType>> { Name = "orderItem" }),
                resolve: context =>
                {
                    var orderItem = context.GetArgument<OrderItem>("orderItem");
                    return orderItemRepository.Create(orderItem);
                });

            Field<MenuType>(
                "createMenu",
                arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<MenuInputType>> { Name = "menu" }),
                resolve: context =>
                {
                    var menu = context.GetArgument<Menu>("menu");
                    return menuRepository.Create(menu);
                });


            //DELETE MUTATIONS
            Field<BooleanGraphType>(
                "deleteUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId" }),
                resolve: context =>
                {
                    var userId = context.GetArgument<Guid>("userId");
                    var user = userRepository.FindById(userId);
                    if (user == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find user in db."));
                        return false;
                    }
                    userRepository.Delete(user);
                    return true;
                }
            );

            Field<BooleanGraphType>(
                "deleteArticle",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "articleId" }),
                resolve: context =>
                {
                    var articleId = context.GetArgument<Guid>("articleId");
                    var article = articleRepository.FindById(articleId);
                    if (article == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find article in db."));
                        return false;
                    }
                    articleRepository.Delete(article);
                    return true;
                }
            );

            Field<BooleanGraphType>(
                "deleteMenuItem",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "menuItemId" }),
                resolve: context =>
                {
                    var menuItemId = context.GetArgument<Guid>("menuItemId");
                    var menuItem = menuItemRepository.FindById(menuItemId);
                    if (menuItem == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find menu item in db."));
                        return false;
                    }
                    menuItemRepository.Delete(menuItem);
                    return true; ;
                }
            );

            Field<StringGraphType>(
                "deleteOrder",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "orderId" }),
                resolve: context =>
                {
                    var orderId = context.GetArgument<Guid>("orderId");
                    var order = orderRepository.FindById(orderId);
                    if (order == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find order in db."));
                        return false;
                    }
                    orderRepository.Delete(order);
                    return true;
                }
            );

            Field<BooleanGraphType>(
                "deleteOrderItem",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "orderItemId" }),
                resolve: context =>
                {
                    var orderItemId = context.GetArgument<Guid>("orderItemId");
                    var orderItem = orderItemRepository.FindById(orderItemId);
                    if (orderItem == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find order item in db."));
                        return false;
                    }
                    orderItemRepository.Delete(orderItem);
                    return true;
                }
            );

            Field<BooleanGraphType>(
                "deleteMenu",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "menuId" }),
                resolve: context =>
                {
                    var menuId = context.GetArgument<Guid>("menuId");
                    var menu = menuRepository.FindById(menuId);
                    if (menu == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find menu in db."));
                        return false;
                    }
                    menuRepository.Delete(menu);
                    return true;
                }
            );

            //UPDATE MUTATIONS
            Field<UserType>(
                "updateUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId" }),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    var userId = context.GetArgument<Guid>("userId");
                    var dbUser = userRepository.FindById(userId);
                    if (dbUser == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find user in db."));
                        return null;
                    }
                    return userRepository.Update(dbUser, user);
                }
            );

            Field<ArticleType>(
                "updateArticle",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ArticleInputType>> { Name = "article" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "articleId" }),
                resolve: context =>
                {
                    var article = context.GetArgument<Article>("article");
                    var articleId = context.GetArgument<Guid>("articleId");
                    var dbArticle = articleRepository.FindById(articleId);
                    if (dbArticle == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find article in db."));
                        return null;
                    }
                    return articleRepository.Update(dbArticle, article);
                }
            );

            Field<MenuItemType>(
                "updateMenuItem",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MenuItemInputType>> { Name = "menuItem" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "menuItemId" }),
                resolve: context =>
                {
                    var menuItem = context.GetArgument<MenuItem>("menuItem");
                    var menuItemId = context.GetArgument<Guid>("menuItemId");
                    var dbMenuItem = menuItemRepository.FindById(menuItemId);
                    if (dbMenuItem == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find menu item in db."));
                        return null;
                    }
                    return menuItemRepository.Update(dbMenuItem, menuItem);
                }
            );

            Field<OrderType>(
                "updateOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderInputType>> { Name = "order" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "orderId" }),
                resolve: context =>
                {
                    var order = context.GetArgument<Order>("order");
                    var orderId = context.GetArgument<Guid>("orderId");
                    var dbOrder = orderRepository.FindById(orderId);
                    if (dbOrder == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find order in db."));
                        return null;
                    }
                    return orderRepository.Update(dbOrder, order);
                }
            );

            Field<OrderItemType>(
                "updateOrderItem",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderItemInputType>> { Name = "orderItem" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "orderItemId" }),
                resolve: context =>
                {
                    var orderItem = context.GetArgument<OrderItem>("orderItem");
                    var orderItemId = context.GetArgument<Guid>("orderItemId");
                    var dbOrderItem = orderItemRepository.FindById(orderItemId);
                    if (dbOrderItem == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find order item in db."));
                        return null;
                    }
                    return orderItemRepository.Update(dbOrderItem, orderItem);
                }
            );

            Field<MenuType>(
                "updateMenu",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MenuInputType>> { Name = "menu" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "menuId" }),
                resolve: context =>
                {
                    var menu = context.GetArgument<Menu>("menu");
                    var menuId = context.GetArgument<Guid>("menuId");
                    var dbMenu = menuRepository.FindById(menuId);
                    if (dbMenu == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find menu in db."));
                        return null;
                    }
                    return menuRepository.Update(dbMenu, menu);
                }
            );
        }
    }
}

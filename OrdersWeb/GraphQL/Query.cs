using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Cors;
using OrdersApp.Data.DataAccess;
using OrdersWeb.GraphQL.Types;
using OrdersWeb.Repository;
using OrdersWeb.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.GraphQL
{        
    [EnableCors("CorsApiPolicy")]
    public class Query : ObjectGraphType
    {

        public Query(IMenuRepository menuRepository, IUserRepository userRepository, IMenuItemRepository menuItemRepository,
            IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IArticleRepository articleRepository)
        {
            Name = "Query";

            Field<ListGraphType<MenuType>>(
                "menus",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<StringGraphType>{
                        Name = "name"
                    }
                }),
                resolve: Query =>
                {
                    var name = Query.GetArgument<String?>("name");
                    if (name != null)
                    {
                        return menuRepository.FindByName(name);
                    }
                    return menuRepository.FindAll();
                });

            Field<MenuType>(
                "menu",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return menuRepository.FindById(id);
                }
            );

            Field<ListGraphType<UserType>>("users", "Query for users", resolve: context => userRepository.FindAll()).AuthorizeWith("Admin");

            Field<UserPageResponseType>("usersCustom",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IntGraphType>{
                        Name = "pageNumber"
                    },
                    new QueryArgument<IntGraphType>{
                        Name = "pageSize"
                    },
                    new QueryArgument<StringGraphType>{
                        Name = "filter"
                    }
                }),
                resolve: context => {

                    var pageNumber = context.GetArgument<int?>("pageNumber");
                    var pageSize = context.GetArgument<int?>("pageSize");

                    var filter = context.GetArgument<String>("filter");

                    return userRepository.FindCustom(pageNumber, pageSize, filter);
                }).AuthorizeWith("Admin");

            Field<UserType>(
                "user",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return userRepository.FindById(id);
                }
            );

            Field<ListGraphType<MenuItemType>>("menuitems", "Query for menu items", resolve: context => menuItemRepository.FindAll());

            Field<MenuItemType>(
                "menuitem",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return menuItemRepository.FindById(id);
                }
            );

            Field<ListGraphType<OrderItemType>>("orderitems", "Query for order items", resolve: context => orderItemRepository.FindAll());

            Field<OrderItemType>(
                "orderitem",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return orderItemRepository.FindById(id);
                }
            );

            Field<ListGraphType<OrderType>>("orders", "Query for orders", resolve: context => orderRepository.FindAll()).AuthorizeWith("Member");

            Field<OrderType>(
                "order",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return orderRepository.FindById(id);
                }
            );

            Field<ListGraphType<ArticleType>>("articles",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<StringGraphType>{
                        Name = "name"
                    }
                }),
                resolve: context => {
                    var name = context.GetArgument<String?>("name");
                    if (name != null)
                    {
                        return articleRepository.FindByName(name);
                    }
                    return articleRepository.FindAll(); 
                });

            Field<ArticleType>(
                "article",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return articleRepository.FindById(id);
                }
            );
        }
    }
}

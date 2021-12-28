using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using OrdersApp.Data.Models;
using OrdersWeb.Repository;
using OrdersWeb.Repository.Abstract;
using System;
using System.Security.Claims;

namespace OrdersWeb.GraphQL.Types
{
    internal class MenuType : ObjectGraphType<Menu>
    {
        public MenuType(IMenuItemRepository menuItemRepository, IDataLoaderContextAccessor dataLoaderContextAccessor) {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Description);
            Field(x => x.ImageId);
            Field(x => x.CoverId);


            Field<ListGraphType<MenuItemType>>(
                "menuitems",
                resolve: context =>
                {
                    var loader =
                        dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<Guid, MenuItem>(
                            "GetMenuItemsByMenuId",
                            menuItemRepository.FindForMenu);
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}
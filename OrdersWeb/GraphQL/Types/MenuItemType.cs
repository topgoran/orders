using GraphQL.DataLoader;
using GraphQL.Types;
using OrdersApp.Data.Models;
using OrdersWeb.Repository;
using System;

namespace OrdersWeb.GraphQL.Types
{
    internal class MenuItemType : ObjectGraphType<MenuItem>
    {
        public MenuItemType(IMenuRepository menuRepository, IArticleRepository articleRepository, IDataLoaderContextAccessor dataLoaderAccessor) {
            Field(x => x.Id);

            Field<ListGraphType<MenuType>>(
                "menus",
                resolve: context =>
                {
                    var loader =
                        dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<Guid, Menu>(
                            "GetMenusByMenuItemId", menuRepository.FindForMenuItem);
                    return loader.LoadAsync(context.Source.MenuId);
                });

            Field<ListGraphType<ArticleType>>(
                "articles",
                resolve: context =>
                {
                    var loader =
                        dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<Guid, Article>(
                            "GetArticlesByMenuItemId", articleRepository.FindForId);
                    return loader.LoadAsync(context.Source.ArticleId);
                });
        }
    }
}
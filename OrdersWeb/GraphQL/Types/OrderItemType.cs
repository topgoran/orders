using GraphQL.DataLoader;
using GraphQL.Types;
using OrdersApp.Data.Models;
using OrdersWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.GraphQL.Types
{
    public class OrderItemType : ObjectGraphType<OrderItem>
    {
        public OrderItemType(IArticleRepository articleRepository, IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Field(x => x.Id);
            Field(x => x.Quantity);
            Field(x => x.Price);


            Field<ListGraphType<ArticleType>>(
                "articles",
                resolve: context =>
                {
                    var loader =
                        dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<Guid, Article>(
                            "GetArticlesByOrderItemId", articleRepository.FindForId);
                    return loader.LoadAsync(context.Source.ArticleId);
                });
        }
    }
}

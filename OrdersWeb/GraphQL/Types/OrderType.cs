using GraphQL.DataLoader;
using GraphQL.Types;
using OrdersApp.Data.Models;
using OrdersWeb.Repository;
using System;

namespace OrdersWeb.GraphQL.Types
{
    internal class OrderType : ObjectGraphType<Order>
    {
        public OrderType(IOrderItemRepository orderItemRepository, IDataLoaderContextAccessor dataLoaderContextAccessor) {
            Field(x => x.Id);
            Field(x => x.Date);
            Field(x => x.Note);

            Field<ListGraphType<OrderItemType>>(
                "orderitems",
                resolve: context =>
                {
                    var loader =
                        dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<Guid, OrderItem>(
                            "GetOrderItemsByOrderId", orderItemRepository.FindForOrderId);
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}
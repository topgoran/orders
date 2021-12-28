using GraphQL.DataLoader;
using GraphQL.Types;
using OrdersApp.Data.Models;
using OrdersWeb.Repository;
using System;

namespace OrdersWeb.GraphQL.Types
{
    internal class UserType : ObjectGraphType<User>
    {
        public UserType(IOrderRepository orderRepository, IDataLoaderContextAccessor dataLoaderContextAccessor) {

            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.Email);
            Field(x => x.UserName);
            Field(x => x.PhoneNumber);
            Field(x => x.City);
            Field(x => x.State);
            Field(x => x.Address);
            Field(x => x.Token);

            Field<ListGraphType<OrderType>>(
                "orders",
                resolve: context =>
                {
                    var loader =
                        dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<Guid, Order>(
                            "GetOrdersByUserId", orderRepository.FindForUser);
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}
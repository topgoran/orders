using OrdersApp.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using OrdersApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrdersWeb.Repository.RepositoryClasses
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(OrdersContext ordersContext) : base(ordersContext) { }


        public async Task<IEnumerable<OrderItem>> FindForOrderId(Guid id)
        {
            return await ordersContext.Set<OrderItem>().Where<OrderItem>(x => x.OrderId == id).ToListAsync();
        }

        public async Task<ILookup<Guid, OrderItem>> FindForOrderId(IEnumerable<Guid> orderIds)
        {
            var orderItems = await ordersContext.Set<OrderItem>().Where<OrderItem>(x => orderIds.Contains(x.OrderId)).ToListAsync();
            return orderItems.ToLookup(r => r.OrderId);
        }

        public OrderItem Update(OrderItem dbEntity, OrderItem entity)
        {
            dbEntity.Quantity = entity.Quantity;
            dbEntity.Price = entity.Price;
            dbEntity.OrderId = entity.OrderId;
            dbEntity.ArticleId = entity.ArticleId;

            ordersContext.Set<OrderItem>().Update(dbEntity);
            SaveChanges();
            return dbEntity;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OrdersApp.Data.DataAccess;
using OrdersApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrdersWeb.Repository.RepositoryClasses
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrdersContext ordersContext) : base(ordersContext) { }


        public async Task<IEnumerable<Order>> FindForUser(Guid id)
        {
            return await ordersContext.Set<Order>().Where<Order>(x => x.UserId == id).ToListAsync();
        }

        public async Task<ILookup<Guid, Order>> FindForUser(IEnumerable<Guid> userIds)
        {
            var orders = await ordersContext.Set<Order>().Where<Order>(x => userIds.Contains(x.UserId)).ToListAsync();
            return orders.ToLookup(r => r.UserId);
        }

        public Order Update(Order dbEntity, Order entity)
        {
            dbEntity.Date = entity.Date;
            dbEntity.Note = entity.Note;
            dbEntity.Note = entity.Note;

            ordersContext.Set<Order>().Update(dbEntity);
            SaveChanges();
            return dbEntity;
        }
    }
}

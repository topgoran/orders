using OrdersApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Task<IEnumerable<Order>> FindForUser(Guid id);

        public Task<ILookup<Guid, Order>> FindForUser(IEnumerable<Guid> userIds);
    }
}

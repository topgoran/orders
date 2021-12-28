using OrdersApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.Repository
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        public Task<IEnumerable<OrderItem>> FindForOrderId(Guid id);

        public Task<ILookup<Guid, OrderItem>> FindForOrderId(IEnumerable<Guid> orderIds);

    }
}

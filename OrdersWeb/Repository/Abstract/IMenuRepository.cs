using OrdersApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.Repository
{
    public interface IMenuRepository : IRepository<Menu>
    {
        public Task<IEnumerable<Menu>> FindForMenuItem(Guid id);

        public Task<ILookup<Guid, Menu>> FindForMenuItem(IEnumerable<Guid> menuItemIds);
        public IQueryable<Menu> FindByName(string firstName);
    }
}

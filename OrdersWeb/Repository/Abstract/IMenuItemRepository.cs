using OrdersApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.Repository.Abstract
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        public Task<IEnumerable<MenuItem>> FindForMenu(Guid id);

        public Task<ILookup<Guid, MenuItem>> FindForMenu(IEnumerable<Guid> menuIds);
    }
}

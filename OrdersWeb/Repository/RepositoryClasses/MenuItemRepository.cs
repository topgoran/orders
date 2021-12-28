using OrdersApp.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using OrdersApp.Data.Models;
using OrdersWeb.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.Repository.RepositoryClasses
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(OrdersContext ordersContext) : base(ordersContext) { }


        public async Task<IEnumerable<MenuItem>> FindForMenu(Guid id)
        {
            return await ordersContext.Set<MenuItem>().Where<MenuItem>(x => x.MenuId == id).ToListAsync();
        }

        public async Task<ILookup<Guid, MenuItem>> FindForMenu(IEnumerable<Guid> menuIds)
        {
            var menuItems = await ordersContext.Set<MenuItem>().Where<MenuItem>(x => menuIds.Contains(x.MenuId)).ToListAsync();
            return menuItems.ToLookup(r => r.MenuId);
        }

        public MenuItem Update(MenuItem dbEntity, MenuItem entity)
        {
            dbEntity.MenuId = entity.MenuId;
            dbEntity.ArticleId = entity.ArticleId;

            ordersContext.Set<MenuItem>().Update(dbEntity);
            SaveChanges();
            return dbEntity;
        }
    }
}

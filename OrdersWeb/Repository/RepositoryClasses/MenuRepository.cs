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
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(OrdersContext ordersContext) : base(ordersContext) { }


        public IQueryable<Menu> FindByName(string name)
        {
            IQueryable<Menu> menus = (from m in ordersContext.Menus where m.Name.Contains(name) select m);
            return menus;
        }

        public async Task<IEnumerable<Menu>> FindForMenuItem(Guid id)
        {
            return await ordersContext.Set<Menu>().Where<Menu>(x => x.Id == id).ToListAsync();
        }

        public async Task<ILookup<Guid, Menu>> FindForMenuItem(IEnumerable<Guid> menuItemIds)
        {
            var menus = await ordersContext.Set<Menu>().Where<Menu>(x => menuItemIds.Contains(x.Id)).ToListAsync();
            return menus.ToLookup(r => r.Id);
        }

        public Menu Update(Menu dbEntity, Menu entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Description = entity.Description;
            dbEntity.CoverId = entity.CoverId;
            dbEntity.ImageId = entity.ImageId;

            ordersContext.Set<Menu>().Update(dbEntity);
            SaveChanges();
            return dbEntity;
        }
    }
}

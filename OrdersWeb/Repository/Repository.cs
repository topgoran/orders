using OrdersApp.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrdersWeb.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IDbContextFactory<OrdersContext> _contextFactory;
        protected readonly OrdersContext ordersContext;
        

        public Repository(OrdersContext ordersContext)
        {
            this.ordersContext = ordersContext;
        }

        public IEnumerable<T> FindAll()
        {
            return ordersContext.Set<T>();
        }
        public Tuple<IQueryable<T>, int> FindAll(int? pageNumber, int? pageSize)
        {
            if (pageNumber != null & pageSize != null)
            {
                return Tuple.Create(ordersContext.Set<T>().Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize), ordersContext.Set<T>().Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize).Count());
            }
            return Tuple.Create((IQueryable<T>)ordersContext.Set<T>().ToList(), ordersContext.Set<T>().ToList().Count());
        }
        public T FindById(Guid id)
        {
            return ordersContext.Set<T>().Find(id);
        }
        public T Create(T entity)
        {
            ordersContext.Set<T>().Add(entity);
            SaveChanges();
            return entity;
        }
        public T Update(T dbEntity, T entity)
        {
            ordersContext.Set<T>().Update(entity);
            SaveChanges();
            return entity;
        }
        public void Delete(T entity)
        {
            ordersContext.Set<T>().Remove(entity);
            SaveChanges();
        }
        public bool SaveChanges()
        {
            return (ordersContext.SaveChanges() >= 0);
        }
    }
}

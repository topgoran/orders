using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrdersWeb.Repository
{
    public interface IRepository<T>
    {
        Tuple<IQueryable<T>, int> FindAll(int? pageNumber, int? pageSize);
        IEnumerable<T> FindAll();
        T FindById(Guid id);
        T Create(T entity);
        T Update(T dbEntity, T entity);
        void Delete(T entity);
        bool SaveChanges();
    }
}

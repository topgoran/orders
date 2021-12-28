using OrdersApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.Repository
{
    public interface IArticleRepository : IRepository<Article>
    {
        public Task<IEnumerable<Article>> FindForId(Guid id);

        public Task<ILookup<Guid, Article>> FindForId(IEnumerable<Guid> articleIds);

        public List<Article> FindByName(String name);
    }
}

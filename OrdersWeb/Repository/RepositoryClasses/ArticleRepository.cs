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
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(OrdersContext ordersContext) : base(ordersContext) { }


        public List<Article> FindByName(string name)
        {
            return ordersContext.Set<Article>().Where<Article>(x => x.Name == name).ToList();
        }

        public async Task<IEnumerable<Article>> FindForId(Guid id)
        {
            return await ordersContext.Set<Article>().Where<Article>(x => x.Id == id).ToListAsync();
        }

        public async Task<ILookup<Guid, Article>> FindForId(IEnumerable<Guid> orderItemIds)
        {
            var articles = await ordersContext.Set<Article>().Where<Article>(x => orderItemIds.Contains(x.Id)).ToListAsync();
            return articles.ToLookup(r => r.Id);
        }

        public Article Update(Article dbEntity, Article entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Description = entity.Description;
            dbEntity.Price = entity.Price;
            dbEntity.ImageId = entity.ImageId;
            dbEntity.CoverId = entity.CoverId;

            ordersContext.Set<Article>().Update(dbEntity);
            SaveChanges();
            return dbEntity;
        }
    }
}

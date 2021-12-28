using GraphQL.Types;
using OrdersApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.GraphQL.Types
{
    public class ArticleType : ObjectGraphType<Article>
    {
        public ArticleType() {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Description);
            Field(x => x.Price);
            Field(x => x.ImageId);
            Field(x => x.CoverId);
        }
    }
}

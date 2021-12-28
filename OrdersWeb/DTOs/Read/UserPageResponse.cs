using OrdersApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.GraphQL.Types
{
    public class UserPageResponse
    {
        public int Count { get; set; }
        public IQueryable<User> Users { get; set; }
    }
}

using OrdersApp.Data.Models;
using OrdersWeb.GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        UserPageResponse FindCustom(int? pageNumber, int? pageSize, String filter);

    }
}

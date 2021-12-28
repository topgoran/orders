using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.GraphQL.Types
{
    public class UserPageResponseType : ObjectGraphType<UserPageResponse>
    {
        public UserPageResponseType()
        {
            Field(x => x.Count);
            Field<ListGraphType<UserType>>("Users");
        }
        
    }
}

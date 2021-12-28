using GraphQL.Types;
using OrdersWeb.DTOs.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.GraphQL.Types
{
    public class RegistrationResponseType : ObjectGraphType<RegistrationResponse>
    {
        public RegistrationResponseType() {
            Field(x => x.Success);
            Field(x => x.Token);
            Field(x => x.Errors);
        }
    }
}

using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.GraphQL.Types.InputTypes
{
    public class OrderInputType : InputObjectGraphType
    {
        public OrderInputType() {
            Name = "orderInput";
            Field<NonNullGraphType<StringGraphType>>("date");
            Field<NonNullGraphType<StringGraphType>>("note");
            Field<NonNullGraphType<GuidGraphType>>("userId");
        }
    }
}

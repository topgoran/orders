using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.GraphQL.Types.InputTypes
{
    public class OrderItemInputType : InputObjectGraphType
    {
        public OrderItemInputType() {
            Name = "orderItemInput";
            Field<NonNullGraphType<IntGraphType>>("quantity");
            Field<NonNullGraphType<DecimalGraphType>>("price");
            Field<NonNullGraphType<GuidGraphType>>("orderId");
            Field<NonNullGraphType<GuidGraphType>>("articleId");
        }
    }
}

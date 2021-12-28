using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.GraphQL.Types.InputTypes
{
    public class MenuItemInputType : InputObjectGraphType
    {
        public MenuItemInputType() {
            Name = "menuItemInput";
            Field<NonNullGraphType<GuidGraphType>>("menuId");
            Field<NonNullGraphType<GuidGraphType>>("articleId");
        }
    }
}

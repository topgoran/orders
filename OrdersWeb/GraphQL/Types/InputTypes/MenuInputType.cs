using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.GraphQL.Types.InputTypes
{
    public class MenuInputType : InputObjectGraphType
    {
        public MenuInputType()
        {
            Name = "menuInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("description");
            Field<NonNullGraphType<IntGraphType>>("imageId");
            Field<NonNullGraphType<IntGraphType>>("coverId");
        }
    }
}

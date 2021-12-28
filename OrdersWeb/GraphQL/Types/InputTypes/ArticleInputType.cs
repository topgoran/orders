using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.GraphQL.Types.InputTypes
{
    public class ArticleInputType : InputObjectGraphType
    {
        public ArticleInputType() {
            Name = "articleInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("description");
            Field<NonNullGraphType<DecimalGraphType>>("price");
            Field<NonNullGraphType<IntGraphType>>("imageId");
            Field<NonNullGraphType<IntGraphType>>("coverId");
        }
    }
}

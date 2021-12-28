using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.DTOs.Read
{
    public class OrderItemReadDto
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public Guid OrderId { get; set; }
        public virtual OrderReadDto Order { get; set; }
        public Guid ArticleId { get; set; }
        public virtual ArticleReadDto Article { get; set; }
    }
}

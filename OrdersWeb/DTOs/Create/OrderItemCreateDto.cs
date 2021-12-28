using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.DTOs.Create
{
    public class OrderItemCreateDto
    {

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("OrderId")]
        public Guid OrderId { get; set; }
        public virtual OrderCreateDto Order { get; set; }

        [ForeignKey("ArticleId")]
        public Guid ArticleId { get; set; }
        public virtual ArticleCreateDto Article { get; set; }
    }
}

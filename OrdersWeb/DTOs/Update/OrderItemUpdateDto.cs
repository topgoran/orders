using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.DTOs.Update
{
    public class OrderItemUpdateDto
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("OrderId")]
        public Guid OrderId { get; set; }
        public virtual OrderUpdateDto Order { get; set; }

        [ForeignKey("ArticleId")]
        public Guid ArticleId { get; set; }
        public virtual ArticleUpdateDto Article { get; set; }
    }
}

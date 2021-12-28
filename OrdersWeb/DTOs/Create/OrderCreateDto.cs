using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.DTOs.Create
{
    public class OrderCreateDto
    {
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(200)]
        public string Note { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public virtual UserCreateDto User { get; set; }
        public virtual ICollection<OrderItemCreateDto> OrderItems { get; set; }
    }
}

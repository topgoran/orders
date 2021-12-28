using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.DTOs.Update
{
    public class OrderUpdateDto
    {
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(200)]
        public string Note { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public virtual UserUpdateDto User { get; set; }
        public virtual ICollection<OrderItemUpdateDto> OrderItems { get; set; }
    }
}

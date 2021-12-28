using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.DTOs.Read
{
    public class OrderReadDto
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }
        public Guid UserId { get; set; }
        public virtual UserReadDto User { get; set; }
        public virtual ICollection<OrderItemReadDto> OrderItems { get; set; }
    }
}

using OrdersWeb.DTOs.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.DTOs
{
    public class MenuReadDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ImageId { get; set; }

        public int CoverId { get; set; }
        public virtual ICollection<MenuItemReadDto> MenuItems { get; set; }
    }
}

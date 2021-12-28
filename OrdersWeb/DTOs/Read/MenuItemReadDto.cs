using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.DTOs.Read
{
    public class MenuItemReadDto
    {
        public Guid Id { get; set; }

        public Guid ArticleId { get; set; }
        public virtual ArticleReadDto Article { get; set; }
        public Guid MenuId { get; set; }
        public virtual MenuReadDto Menu { get; set; }
    }
}

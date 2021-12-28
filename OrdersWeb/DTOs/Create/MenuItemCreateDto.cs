using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.DTOs.Create
{
    public class MenuItemCreateDto
    {

        [ForeignKey("ArticleId")]
        public Guid ArticleId { get; set; }
        public virtual ArticleCreateDto Article { get; set; }

        [ForeignKey("MenuId")]
        public Guid MenuId { get; set; }
        public virtual MenuCreateDto Menu { get; set; }
    }
}

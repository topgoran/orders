using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.DTOs.Update
{
    public class MenuItemUpdateDto
    {
        [ForeignKey("ArticleId")]
        public Guid ArticleId { get; set; }
        public virtual ArticleUpdateDto Article { get; set; }

        [ForeignKey("MenuId")]
        public Guid MenuId { get; set; }
        public virtual MenuUpdateDto Menu { get; set; }
    }
}

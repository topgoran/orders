using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp.Data.Models
{
    public class MenuItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("ArticleId")]
        public Guid ArticleId { get; set; }
        public virtual Article Article { get; set; }

        [ForeignKey("MenuId")]
        public Guid MenuId { get; set; }
        public virtual Menu Menu { get; set; }

    }
}

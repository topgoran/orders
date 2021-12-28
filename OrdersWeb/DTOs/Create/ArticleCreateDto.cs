using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWeb.DTOs.Create
{
    public class ArticleCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ImageId { get; set; }

        [Required]
        public int CoverId { get; set; }
        public virtual ICollection<MenuItemCreateDto> MenuItems { get; set; }
        public virtual ICollection<OrderItemCreateDto> OrderItems { get; set; }
    }
}

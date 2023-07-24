using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme_Moto_Store.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; } //Shortcut: prop tab

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public string Image { get; set; }

        [Range(1,3000,ErrorMessage ="Price must be within $1 to $3000")]
        public double Price { get; set; }

        public int ItemTypeId { get; set; }
        public ItemType ItemType { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}

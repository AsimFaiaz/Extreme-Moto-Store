using System.ComponentModel.DataAnnotations;

namespace Extreme_Moto_Store.Model
{
    public class Category
    {
        [Key]
        public int id { get; set; } //Shortcut: prop tab

        [Required]
        public String name { get; set; }

        public int displayOrder { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Extreme_Moto_Store.Model
{
    public class Category
    {
        [Key]
        public int id { get; set; } //Shortcut: prop tab

        [Required]
        [Display(Name ="Name")]
        public String name { get; set; }

        [Display(Name = "Display Order")]
        [Range(0,100, ErrorMessage ="Please limit 1 to 100")]
        public int displayOrder { get; set; }
    }
}

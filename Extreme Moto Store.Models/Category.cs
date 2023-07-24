using System.ComponentModel.DataAnnotations;

namespace Extreme_Moto_Store.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } //Shortcut: prop tab

        [Required]
        [Display(Name ="Name")]
        public String Name { get; set; }

        [Display(Name = "Display Order")]
        [Range(0,100, ErrorMessage ="Please limit 1 to 100")]
        public int DisplayOrder { get; set; }
    }
}

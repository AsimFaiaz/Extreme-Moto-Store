using System.ComponentModel.DataAnnotations;

namespace Extreme_Moto_Store.Models
{
    public class ItemType
    {
        [Key]
        public int Id { get; set; } //Shortcut: prop tab

        [Required]
        public String Name { get; set; }
    }
}

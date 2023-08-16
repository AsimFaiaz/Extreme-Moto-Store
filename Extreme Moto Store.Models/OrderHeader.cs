using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Extreme_Moto_Store.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Order Total")]
        public double OrderTotal { get; set; }

        [Required]
        [Display(Name = "Pick Up time")]
        public DateTime PickUpTime { get; set; }

        [Required]
        [NotMapped]
        [Display(Name = "Pick Up date")]
        public DateTime PickUpDate { get; set; }

        public String Status { get; set; }

        public String? Comments { get; set; }

        public String? TransactionId { get; set; }

        [Display(Name = "Customer Name")]
        public string PickUpName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }



    }
}

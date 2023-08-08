using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme_Moto_Store.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]                     //IMP: So it will not validate any product from cart if the ID is not exist          
        public Product Product { get; set; }

        [Range(1, 5, ErrorMessage = "Please select minimum 1 or maximum 5 to add to cart")]  //For count functionality on View details page
        public int Count { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]                     //IMP: So it will not validate any product from cart if the ID is not exist  
        public ApplicationUser ApplicationUser { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models.ViewModel
{
    public class DetailedOrderViewModel
    {
        [Required]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"[A-Z][a-zA-Z\s]*", ErrorMessage = "Must start with an upper-case letter and only contain letters and spaces.")]
        [Display(Name = "Customer")]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }

        [Display(Name = "Delivered Date")]
        public DateTime? DeliveredDate { get; set; }

        [Display(Name = "Total items in Order")]
        public int TotalProducts { get; set; }
    }
}

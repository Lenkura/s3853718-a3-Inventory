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
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"[A-Z][a-zA-Z\s]*", ErrorMessage = "Must start with an upper-case letter and only contain letters and spaces.")]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(200)]
        public string DeliveryAddress { get; set; }

        public DateTime? DeliveredDate { get; set; }

        [Display(Name = "No. Products in Order")]
        public int TotalProducts { get; set; }
    }
}

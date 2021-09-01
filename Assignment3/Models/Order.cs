using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int OrderID { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"[A-Z][a-zA-Z\s]*", ErrorMessage = "Must start with an upper-case letter and only contain letters and spaces.")]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(200)]
        public string DeliveryAddress { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DeliveredDate { get; set; }

    }
}

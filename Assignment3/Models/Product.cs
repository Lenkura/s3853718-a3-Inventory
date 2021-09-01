using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"[A-Z][0-9a-zA-Z\s]*", ErrorMessage = "Must start with an upper-case letter and only contain letters, numbers, and spaces")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}

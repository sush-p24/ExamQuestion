using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamQuestion.Models
{
    public class Product
    {
        [Key]
        [Required(ErrorMessage ="ProductId is mandatory")]
        [Display(Name ="ProductId")]
        public int ProductId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "ProductName cannot be empty")]
        [Display(Name = "Product Name")]
        [StringLength(50,ErrorMessage ="The {0}Cannot exceed {1} words")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Rate cannot be empty")]
        [Display(Name = "Rate")]
      [DataType(DataType.Currency)]
        public decimal Rate { get; set; }



        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Description cannot be empty")]
        [Display(Name = "Description")]
        [StringLength(200, ErrorMessage = "The {0} Cannot exceed {1} length")] 
        public string  Description { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Category cannot be empty")]
        [Display(Name = "Category Name")]
        [StringLength(50, ErrorMessage = "The {0} Cannot exceed {1} length")]
        public string CategoryName { get; set; }
    }
}
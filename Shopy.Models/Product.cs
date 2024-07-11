using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Auther { get; set; }
        [Required]
        [Range(1,1000)]
        [Display(Name= "List Price")]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name = "Price when buy 1-50")]
        public double Price { get; set; }
        [Required]
        [Range(1, 1000)]
        [Display(Name = "Price when buy +50")]
        public double Price50 { get; set; }
        [Required]
        [Range(1, 1000)]
        [Display(Name = "Price when buy +100")]
        public double Price100 { get; set; }
        [ForeignKey("Category")]
        [ValidateNever]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImageURL { get; set; }


    }
}

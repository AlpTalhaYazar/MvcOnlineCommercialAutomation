using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Category
    {
        [Key]
        public int                  CategoryID      { get; set; }

        [Display(Name = "Category Name")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string               CategoryName    { get; set; }

        public ICollection<Product> Products        { get; set; }   // We are saying that every Category contains multiple Products
    }
}
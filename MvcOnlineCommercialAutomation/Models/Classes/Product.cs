using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }

        public short Stock { get; set; }

        [Display(Name = "Purchase Price")]
        public decimal PurchasePrice { get; set; }

        [Display(Name = "Sale Price")]
        public decimal SalePrice { get; set; }

        public bool Status { get; set; }

        [Display(Name = "Product Image")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }

        [Display(Name = "Category Name")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }   //We define Product's Category

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}
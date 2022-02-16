using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Invoince
    {
        [Key] public int InvoinceID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoinceItemNo { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoinceSerialNo { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Hour { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxOffice { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Consigner { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Recipient { get; set; }

        public decimal Total { get; set; }

        public ICollection<InvoinceItem> InvoinceItems { get; set; }
    }
}
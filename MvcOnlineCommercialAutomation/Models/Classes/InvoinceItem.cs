using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class InvoinceItem
    {
        [Key] public int InvoinceItemID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }

        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }

        public int InvoinceID { get; set; }
        public virtual Invoince Invoince { get; set; }
    }
}
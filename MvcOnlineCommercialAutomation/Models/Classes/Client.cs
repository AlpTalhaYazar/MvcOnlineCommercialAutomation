using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter olabilir")]
        public string ClientFirstName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Please write something")]
        public string ClientLastName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string ClientCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ClientMail { get; set; }

        public bool Status { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}
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

        [Display(Name = "Client First Name")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter olabilir")]
        public string ClientFirstName { get; set; }

        [Display(Name = "Client Last Name")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Please write something")]
        public string ClientLastName { get; set; }

        [Display(Name = "Client City")]
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string ClientCity { get; set; }

        [Display(Name = "Client Mail")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ClientMail { get; set; }

        [Display(Name = "Client Password")]
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string ClientPassword { get; set; }

        public bool Status { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}
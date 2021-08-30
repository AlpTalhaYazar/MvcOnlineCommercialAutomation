using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Display(Name = "Employee First Name")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeFirstName { get; set; }

        [Display(Name = "Employee Last Name")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeLastName { get; set; }

        [Display(Name = "Employee Image")]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string EmployeeImage { get; set; }

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}
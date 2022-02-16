using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Department
    {
        [Key] public int DepartmentID { get; set; }

        [Display(Name = "Department Name")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmentName { get; set; }

        public bool Status { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
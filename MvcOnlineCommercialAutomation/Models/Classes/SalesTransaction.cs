using System;
using System.ComponentModel.DataAnnotations;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class SalesTransaction
    {
        [Key] public int SaleID { get; set; }

        //Product
        //Client
        //Employee
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        public int ProductID { get; set; }
        public int ClientID { get; set; }
        public int EmployeeID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
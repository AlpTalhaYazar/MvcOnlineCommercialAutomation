using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Context: DbContext
    {
        public DbSet<Admin>             Admins              { get; set; }
        public DbSet<Category>          Categories          { get; set; }
        public DbSet<Client>            Clients             { get; set; }
        public DbSet<Department>        Departments         { get; set; }
        public DbSet<Employee>          Employees           { get; set; }
        public DbSet<Expense>           Expenses            { get; set; }
        public DbSet<Invoince>          Invoinces           { get; set; }
        public DbSet<InvoinceItem>      InvoinceItems       { get; set; }
        public DbSet<Product>           Products            { get; set; }
        public DbSet<SalesTransaction>  SalesTransactions   { get; set; }
    }
}
namespace EFAutoLotConsoleApp {
   using System;
   using System.Data.Entity;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Linq;

   public partial class AutoLotConnection : DbContext {
      public AutoLotConnection()
          : base("name=AutoLotConnection") {
      }

      public virtual DbSet<CreditRisk> CreditRisks { get; set; }
      public virtual DbSet<Customer> Customers { get; set; }
      public virtual DbSet<Inventory> Inventories { get; set; }
      public virtual DbSet<Order> Orders { get; set; }

      protected override void OnModelCreating(DbModelBuilder modelBuilder) {
         modelBuilder.Entity<CreditRisk>()
             .Property(e => e.FirstName)
             .IsUnicode(false);

         modelBuilder.Entity<CreditRisk>()
             .Property(e => e.LastName)
             .IsUnicode(false);
      }
   }
}

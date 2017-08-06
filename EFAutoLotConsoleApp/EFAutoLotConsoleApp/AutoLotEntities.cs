namespace EFAutoLotConsoleApp {
   using System;
   using System.Data.Entity;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Linq;

   public partial class AutoLotEntities : DbContext {

      public AutoLotEntities()
          : base("name=AutoLotEntities") {
      }

      public virtual DbSet<CreditRisks> CreditRisks { get; set; }
      public virtual DbSet<Order> Orders { get; set; }
      public virtual DbSet<Custumer> Custumers { get; set; }
      public virtual DbSet<Car> Cars { get; set; }

      protected override void OnModelCreating(DbModelBuilder modelBuilder) {
         modelBuilder.Entity<CreditRisks>()
             .Property(e => e.FirstName)
             .IsUnicode(false);

         modelBuilder.Entity<CreditRisks>()
             .Property(e => e.LastName)
             .IsUnicode(false);

         modelBuilder.Entity<Custumer>()
             .HasMany(e => e.Orders)
             .WithRequired(e => e.Custumer)
             .WillCascadeOnDelete(false);

         modelBuilder.Entity<Car>()
             .HasMany(e => e.Orders)
             .WithRequired(e => e.Car)
             .WillCascadeOnDelete(false);
      }

   }
}

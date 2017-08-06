namespace EFAutoLotConsoleApp {
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   [Table("Order")]
   public partial class Order {

      public int OrderID { get; set; }

      public int? CustID { get; set; }

      public int? CarID { get; set; }

      public virtual Customer Customer { get; set; }

      public virtual Inventory Inventory { get; set; }
   }
}

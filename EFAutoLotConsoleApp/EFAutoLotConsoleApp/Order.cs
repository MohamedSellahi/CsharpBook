namespace EFAutoLotConsoleApp {
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.ComponentModel.DataAnnotations.Schema;
   using System.Data.Entity.Spatial;

   [Table("CurrentOrder")]
   public partial class Order {

      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.None)]
      public int OrderID { get; set; }

      public int CustID { get; set; }

      public int CarID { get; set; }

      public virtual Car Car { get; set; }

      public virtual Custumer Custumer { get; set; }
   }
}

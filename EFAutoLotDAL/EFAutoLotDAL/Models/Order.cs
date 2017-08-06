using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFAutoLotDAL.Models {

   [Table("Order")]
   public class Order {

      [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int OrderId { get; set; }

      [Required]
      public int CustId { get; set; }

      [Required]
      public int CarId { get; set; }

      // navigation properties

      [ForeignKey("CustId")]
      public virtual Customer Customer { get; set; }

      [ForeignKey("CarId")]
      public virtual Inventory Car { get; set; }

   }
}

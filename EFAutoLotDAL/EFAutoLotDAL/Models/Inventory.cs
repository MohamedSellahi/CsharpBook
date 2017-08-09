using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFAutoLotDAL.Models {

   [Table("Inventory")]
   public partial class Inventory {

      [Key]
      public int CarId { get; set; }

      [StringLength(50)]
      public string Maker { get; set; }

      [StringLength(50)]
      public string Color { get; set; }

      [StringLength(50)]
      public string PetName { get; set; }

      [Timestamp]
      public byte[] TimeStamp { get; set; }


      //Navigation property to account for the relation of 0-->N 
      // between a car and an order 
      public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
   }
}

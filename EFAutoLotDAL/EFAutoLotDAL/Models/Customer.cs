using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 

namespace EFAutoLotDAL.Models {

   [Table("Customer")]
   public class Customer {

      [Key]
      public int CustId { get; set; }

      [StringLength(50)]
      public string FirstName { get; set; }

      [StringLength(50)]
      public string LastName { get; set; }

      [Timestamp]
      public byte[] TimeStamp { get; set; }

      [NotMapped]
      public string FullName => FirstName + " " + LastName;

      public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
   }

}

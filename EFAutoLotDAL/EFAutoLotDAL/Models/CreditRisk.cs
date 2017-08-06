using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutoLotDAL.Models {
   [Table("CreditRisks")]
   public class CreditRisk {

      [Key]
      public int CustId { get; set; }

      [StringLength(50)]
      public string FirstName { get; set; }

      [StringLength(50)]
      public string LastName { get; set; }

   }
}

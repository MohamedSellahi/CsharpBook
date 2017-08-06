using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace EFAutoLotDAL.Models {
   partial class Inventory {
      public override string ToString() {
         // PetName can be null 

         return $"{this.PetName ?? "**NO Name**"} is a {this.Color} {this.Maker}" +
            $"with ID {this.CarId}";

      }
      
      [NotMapped]
      public string MakeColor => $"{Maker} + {Color}";
   }
}

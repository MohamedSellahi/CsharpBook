using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutoLotConsoleApp {
   public partial class Car {

      public override string ToString() {
         // Since the PetName collumns could be empty, supply the default name to noname 

         return $"{this.CarNickName.Trim() ?? "**No Name**"} is a {this.Color.Trim()} {this.Maker} " +
            $"With ID {this.CarID}"; 
      }
   }
}

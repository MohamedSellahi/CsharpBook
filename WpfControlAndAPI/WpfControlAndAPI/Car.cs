using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfControlAndAPI {
  class Car {
    public int CarId { get; set; }
    public string Maker { get; set; }
    public string Color { get; set; }
    public string PetName { get; set; }

    public override string ToString() {
      return string.Format("{0}, {1}, and made by {2}", PetName, Color, Maker);
    }
  }
}

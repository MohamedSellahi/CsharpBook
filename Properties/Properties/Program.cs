using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties {
  class Program {
    static void Main(string[] args) {
      Employee e = new Employee("Mohamed", 33, 007, 100f);
      e.DisplayStats();
      Console.WriteLine("NbEmployees: {0}", Employee.NbEmployee);

    }// main 

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringIndexer {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with indexers *****\n");
      PersonCollection myPeople = new PersonCollection();
      myPeople["Homer"] = new Person("Homer", "Simpson", 40);
      myPeople["Marge"] = new Person("Marge", "Simpson", 38);

      //  get Homer and print data
      Person Homer = myPeople["Homer"];
      Console.WriteLine(Homer);


    }
  }
}

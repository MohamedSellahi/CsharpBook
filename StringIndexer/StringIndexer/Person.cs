using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringIndexer {
  class Person {
    public int Age { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Person() {}

    public Person(string fname, string lname, int age) {
      FirstName = fname;
      LastName = lname;
      Age = age;
    }

    public override string ToString() {
      return string.Format("Name: {0} {1}, Age: {2}", FirstName, LastName, Age);
    }



  }
}

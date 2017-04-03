using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsevableCollection {
  class Person {
    public string Fname { get; set; }
    public string Lname { get; set; }
    public int Age { get; set; }

    public Person() {

    }

    public Person(string fname, string lname, int age) {
      Fname = fname;
      Lname = lname;
      Age = age; 
    }

    public override string ToString() {
      return string.Format("{0}, {1}, Age {2}", Fname, Lname, Age);
    }

  }
}

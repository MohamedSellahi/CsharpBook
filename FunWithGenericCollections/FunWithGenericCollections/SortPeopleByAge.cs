using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGenericCollections {
  class SortPeopleByAge : IComparer<Person> {

    public int Compare(Person firstperson, Person secondPerson) {
      if (firstperson.Age > secondPerson.Age)
        return 1;
      if (firstperson.Age < secondPerson.Age)
        return -1;
      else
        return 0;
    }




  }
}

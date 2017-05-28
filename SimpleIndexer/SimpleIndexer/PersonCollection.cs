using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// strongly typed custom collection of people 
namespace SimpleIndexer {
  class PersonCollection : IEnumerable {

    private ArrayList arPeople = new ArrayList();

    public PersonCollection() {}
    // Cast for the caller 
    public Person GetPerson(int pos) {
      return (Person)arPeople[pos];
    }

    // Insert only person objects 
    public void AddPerson(Person p) {
      arPeople.Add(p);
    }

    public void ClearPeople() {
      arPeople.Clear();
    }

    public int Count { get { return arPeople.Count; } }

    public int Length { get { return arPeople.Count; }}

    //public int Length { get; internal set; }

    // Foreach enumeration support
    // make it explicit implementation. can't be called from 
    // object level

    IEnumerator IEnumerable.GetEnumerator() {
      return arPeople.GetEnumerator();
    }
    

    // Custom indexer for this class 

    public Person this[int index] {
      get { /* return the specified index here */
        return (Person)arPeople[index];
      }
      set { /* set the specified index to value here */
        arPeople.Insert(index, value);
      }
    }

  }


 
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndxerWithMultipleDimension {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with indexers of multiple dimensions\n");
      DataTable myTable = new DataTable();

      myTable.Columns.Add(new DataColumn("FirstName"));
      myTable.Columns.Add(new DataColumn("LastName"));
      myTable.Columns.Add(new DataColumn("Age"));

      // now add rows to table
      myTable.Rows.Add("Mel", "Gibson", 65);
      //
      Console.WriteLine("First Name: {0}", myTable.Rows[0][0]);
      Console.WriteLine("Last Name: {0}", myTable.Rows[0][1]);
      Console.WriteLine("Age : {0}", myTable.Rows[0][2]);



    }


    // exemple of Indexer defined on Interface type
    interface IStringContainer {
      string this[int index] { get; set; }
    }

    // some class implementing IStingContainer 
    class SomeClass: IStringContainer {

      private List<string> myStrings = new List<string>();

      public string this[int index] {
        get { /* return the specified index here */
          return myStrings[index];
        }
        set { /* set the specified index to value here */
          myStrings.Insert(index, value);
        }
      }


    }

  }
}

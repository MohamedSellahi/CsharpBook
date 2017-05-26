using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Entity;
using System.Data.SqlClient;
namespace MySQL_DBtest {
  class Program {
    static void Main(string[] args) {
      using (UniversityDB db = new UniversityDB()) {
        
        instructor inst = new instructor();
        var instrs = db.instructors;
        

        foreach (var item in instrs.SqlQuery("select * from dbo.instructor")) {
          Console.WriteLine(item.name);
        }



        foreach (var item in typeof(instructor).GetCustomAttributes()) {
          Console.WriteLine(item);
        }

        foreach (var item in typeof(instructor).GetProperties()) {
          Console.WriteLine("method: {0}", item.Name);
          foreach (var ma in item.GetCustomAttributes()) {
            Console.WriteLine(ma);
          }
        }
      }


    }
  }
}

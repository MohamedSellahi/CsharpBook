using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAccessmodifiers {
    class Program {
        static void Main(string[] args) {
            Employee emp = new Employee("Moh", 15, 100);
            emp.DisplayStats();
            emp.setName("Mohamed");
            emp.DisplayStats();

            Employee emp2 = new Employee();
            emp2.setName("This is a very long name that should generate an error message");                        
        }
        // resume on dotNet properties



    }// end of program

   

}// end of namespace 

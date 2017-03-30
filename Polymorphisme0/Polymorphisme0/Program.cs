using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphisme0 {
    class Program {
        static void Main(string[] args) {
        }
    }// end of program 



    public class Shape {  // public to allow use outsiude assembly

        // methods 
        public virtual void Draw() {
            Console.WriteLine("Drawing shape");
        }
    }


    public class Circle: Shape {

    }


}

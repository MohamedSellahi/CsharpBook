using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass {
    class Program {
        static void Main(string[] args) {
            TimeUtilities.PrintDate();
            TimeUtilities.PrintTime();
        }

    }

    static class TimeUtilities {
        
        public static void PrintTime() {
            Console.WriteLine(DateTime.Now.ToShortTimeString());
        }

        public static void PrintDate() {
            Console.WriteLine(DateTime.Today.ToShortDateString());
        }

    }







}// end of program


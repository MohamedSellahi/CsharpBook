using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMemeber {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("****** fun with Static Data ******");
            SavingAcount s1 = new SavingAcount(50);
            SavingAcount s2 = new SavingAcount(100);


            //Calling static methods 
            Console.WriteLine("interest rate is: {0}", SavingAcount.GetInterrestRate());
            SavingAcount.SetInterrestRate(0.05);
            Console.WriteLine("the new interest rate is: {0}", SavingAcount.GetInterrestRate());
            // make new object does not reset the interrest 
            SavingAcount s3 = new SavingAcount(150.5f);
            Console.WriteLine("the new interest rate is: {0}", SavingAcount.GetInterrestRate());



        }
    }

    class SavingAcount {
        // instance level data 
        public double currBalance;

        // class level data
        //public static double currInterrestrate = 0.04;  // inline initialization of static data 
        public static double currInterrestrate ;

        // Constructors 
        public SavingAcount(double balance) {
            //currInterrestrate = 0.02;  // do not do this  
            currBalance = balance;
        }
        // static constructor 
        static SavingAcount() {
            Console.WriteLine("in static constructor");
            currInterrestrate = 0.03;
        }

        // static methods 
        ///<summary
        /// Static methods to set and get interest rate
        /// Get the current interrest rate 
        /// 
        ///</summary>
        public static double GetInterrestRate() {
            return currInterrestrate;
        }

        public static void SetInterrestRate(double rate) {
            currInterrestrate = rate;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Encapsulation: traditional accessors and mutators 

namespace ClassAccessmodifiers {
    class Employee {
        // field data 
        private string empName;
        private int empId;
        private double currPay;

        // constructors
        public Employee() { }
        /// <summary>
        /// Creates an employee with name, id and pay 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <param name="pay"></param>
        public Employee(string name, int id, float pay) {
            empName = name;
            empId = id;
            currPay = pay;
        }

        // methods 
        public void GiveBonus(float amount) {
            currPay += amount;
        }

        public void DisplayStats() {
            Console.WriteLine("Name: {0}", empName);
            Console.WriteLine("ID: {0}", empId);
            Console.WriteLine("Pay: {0}", currPay);
        }

        // setter 
        public  string getName() {
            return empName;
        }

        // getter 
        public void setName(string name) {
            // lets check the length of the name 
            if (name.Length > 15)
                Console.WriteLine("Error! Name must be less than 16 chars!");
            else
                empName = name;
        }





    }// end of class 
}

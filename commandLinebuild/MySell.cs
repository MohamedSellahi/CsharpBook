// A simple C# application 
using System;
//using System.Windows.Forms;

namespace Project0
{
    class TestApp
    {
        static void Main(string[] args){
            Console.WriteLine("testing 1, 2, 3");
            
            /***************************************/
            //System.Windows.Forms.MessageBox.Show("Hello...");
            HelloMessage h = new HelloMessage();
            h.Speak();

        }
    }
}
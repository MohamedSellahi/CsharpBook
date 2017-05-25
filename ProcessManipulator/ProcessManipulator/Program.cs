using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; 

namespace ProcessManipulator {
  class Program {
    static void Main(string[] args) {
      ListAllProcesses();
    }



    // get all the processes running on the actual machine 
    // ordered by PID
    static void ListAllProcesses() {
      var runningProcess = from proc in Process.GetProcesses(".")
                           orderby proc.Id
                           select proc;
      // Print PID and the names of each process 
      foreach (var p in runningProcess) {
        string infos = string.Format("-> PID: {0}\tName: {1}",
          p.Id, p.ProcessName);
        Console.WriteLine(infos);
      }

      Console.WriteLine("*****************************************\n");
    }
  }

}

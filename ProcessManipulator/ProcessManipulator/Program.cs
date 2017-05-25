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

      //while (true) {
      //  try {
      //    string userInput = Console.ReadLine();
      //    if (userInput == "q") {
      //      break;
      //    }
      //    int pid = Convert.ToInt32(userInput);
      //    GetSpecificProcess(pid);

      //  }
      //  catch (Exception e) {
      //    Console.WriteLine("Please enter an integer");
      //  }
      //}

      // Investigatin a Process's thread

      //while (true) {
      //  try {
      //    string userInput = Console.ReadLine();
      //    if (userInput == "q") {
      //      break;
      //    }
      //    int pid = Convert.ToInt32(userInput);
      //    EnumerateThreadsForId(pid);

      //  }
      //  catch (Exception e) {
      //    Console.WriteLine("Please enter an integer");
      //  }
      //}

      //while (true) {
      //  try {
      //    string userInput = Console.ReadLine();
      //    if (userInput == "q") {
      //      break;
      //    }
      //    int pid = Convert.ToInt32(userInput);
      //    EnumerateForId(pid);

      //  }
      //  catch (Exception e) {
      //    Console.WriteLine("Please enter an integer");
      //  }
      //}
      StartAndKillProcess();

    }

    private static void EnumerateForId(int pid) {
      Process theProc = null;
      try {
        theProc = Process.GetProcessById(pid);
      }
      catch (ArgumentException ex ) {
        Console.WriteLine(ex.Message);
        return;
      }

      Console.WriteLine("here are the loaded modules for {0}",theProc.ProcessName);
      ProcessModuleCollection theMods = theProc.Modules;
      foreach (ProcessModule pm in theMods) {
        string infos = string.Format("-> Mod Name: {0}", pm.ModuleName);
        Console.WriteLine(infos);
      }
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

    // Get specific process 
    static void GetSpecificProcess(int pid) {
      Process theProc = null;
      try {
        theProc = Process.GetProcessById(pid);
        Console.WriteLine("PID: {0} corresponds to -> {1}", theProc.Id, theProc.ProcessName);
      }
      catch (Exception ex) {
        Console.WriteLine(ex.Message);
      }
    }

    // GEt threads of a process 
    static void EnumerateThreadsForId(int pid) {
      Process theProc = null;
      try {
        theProc = Process.GetProcessById(pid);
      }
      catch (ArgumentException ex) {
        Console.WriteLine(ex.Message);
        return;
      }

      ProcessThreadCollection theThreads = theProc.Threads;
      foreach (ProcessThread pt in theThreads) {
        string infos = string.Format("-> Thread ID:{0}\t Start Time: {1}\tPriority:{2}",
          pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
        Console.WriteLine(infos);
      }
      Console.WriteLine("***************************************");




    }

    static void StartAndKillProcess() {
      Process ieProc = null;
      // launch internet explorer, and go to facebook 
      // use ProcessStartInfo Class to tune the start up 
      // of the process 
      try {
        ProcessStartInfo startInfo = new
          ProcessStartInfo(@"C:\Program Files\Internet Explorer\iexplore.exe",
                             "www.facebook.com");
        startInfo.WindowStyle = ProcessWindowStyle.Minimized;
        ieProc = Process.Start(startInfo);
      }
      catch (InvalidOperationException ex) {
        Console.WriteLine(ex.Message);
      }

      Console.WriteLine("Hit enter key to kill {0}...", ieProc.ProcessName);
      Console.ReadLine();
      try {// try to kill ie
        ieProc.Kill();
      }
      catch (InvalidOperationException ex) {
        Console.WriteLine(ex.Message);
      }
    }
  }

}

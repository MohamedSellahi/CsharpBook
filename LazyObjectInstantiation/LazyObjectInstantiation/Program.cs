using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyObjectInstantiation {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with Lazy instantiation *****");
      /* this callser does not care obout getting all songs 
       * but indirectly created 10000 objects!
       * */
       // here the allocation of allsongs will not happen since
       // the member has not been used from code 
      MediaPlayer myPlayer = new MediaPlayer();
      myPlayer.Play();

      /* here we the CLR will instantiate allSongs since 
       * it is used in the code */
      MediaPlayer myPlayer2 = new MediaPlayer();
      myPlayer2.GetAllTracks();

      /* Lazy object instantiation is usefull to decrease unnecessary
       * allocation of objects. it is also used for members who have
       * expensive creation code, such as invoking remote methods 
       * communication with relationnal databases and soforth . */
       
    }


  }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LazyObjectInstantiation {
  class Song {
    public string Artist { get; set; }
    public string TrackName { get; set; }
    public double TrackLength { get; set; }
  }

  class AllTracks {
    // Our media player can have a maximum 
    // of 10,000 songs 
    private Song[] allSongs = new Song[10000];

    public AllTracks() {
      // assume we fill up the array 
      // of songs 
      Console.WriteLine("Filling up the songs!");
    }

    public AllTracks(string str) {
      Console.WriteLine("Filling up the songs! using " + str);
    }
  }

  // The MediaPlayer has-an AllTracks object.
  class MediaPlayer {
    public void Play() { Console.WriteLine("playing Songs..."); }
    public void Pause() { }
    public void Stop() { }

    //private AllTracks allSongs = new AllTracks();
    /* replace this declaration with */

    //private Lazy<AllTracks> allSongs = new Lazy<AllTracks>();

    // this line of code will not instantiate allSongs
    // unless it is used somewhere in the code 

    /* Use lambda expression additionnal code when 
     * the tracks are created. a custom constructor can be specified
     */
    private Lazy<AllTracks> allSongs = new Lazy<AllTracks>(() => {
      Console.WriteLine("Creating All tracks object!");
      //return new AllTracks();
      return new AllTracks("a custom constructor");
    }
    );


    public AllTracks GetAllTracks() {
      // return all the songs
      // return allSongs;//<-- replace this line 
      return allSongs.Value;
    }

  }

}
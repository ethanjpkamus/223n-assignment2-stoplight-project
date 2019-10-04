//Author: Ethan Kamus
//Email: ethanjpkamus@csu.fullerton.edu

//Purpose: to emulate a stoplight

using System;
using System.Windows.Forms;

public class stoplightmain{

     static void Main(string[] args){

          System.Console.WriteLine("Welcome to the Main method of the StopLight program.");
          stoplightuserinterface application = new stoplightuserinterface();
          Application.Run(application);
          System.Console.WriteLine("Main method will now shutdown.");

     }//End of Main

}//End of redlightmain

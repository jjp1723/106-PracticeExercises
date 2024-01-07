using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating the graph object and a string to hold the current room's name
            Graph map = new Graph();
            string room = "DRAWING ROOM";

            //Listing all of the rooms in the map
            map.ListAllVertices();

            //Creating a while loop to keep the program running
            bool play = true;
            while(play)
            {
                //Displaying a menu of rooms to the player based on their current room
                Console.Write("\n\nYou are currently in the " + map.GetRoom(room) + "\nNearby are:\t");
                foreach(Vertex adjRoom in map.GetAdjacentList(room))
                {
                    Console.Write(adjRoom.Name + "\t");
                }

                //Asking the player where they would like to go next and verifying that their choice is valid
                Console.WriteLine("\nWhere would you like to go?");
                string nextRoom = Console.ReadLine();
                if(map.IsConnected(room, nextRoom.ToUpper()))
                {
                    room = nextRoom.ToUpper();
                }
                else
                {
                    Console.WriteLine("Sorry, but that is not a valid choice");
                }

                //If the current room is the exit, the program ends
                if (room.Equals("EXIT ROOM"))
                {
                    Console.WriteLine("\n\nYou have successfully escaped, even though you were in paradise");
                    play = false;
                }
            }



            //Keeps the Console Window Open
            Console.ReadLine();
        }
    }
}

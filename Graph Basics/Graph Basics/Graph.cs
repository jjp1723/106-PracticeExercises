using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Basics
{
    class Graph
    {
        // ----- Fields -----
        protected List<Vertex> vertices;
        protected Dictionary<string, List<Vertex>> adjacencies;



        // ----- Constructor -----
        public Graph()
        {
            //Initializing the vertices List and adjancencies Dictionary
            vertices = new List<Vertex>();
            adjacencies = new Dictionary<string, List<Vertex>>();

            //Creating the vertices and adding them to vertices list
            Vertex drawRoom = new Vertex("DRAWING ROOM", "In this room, you can draw stuff");
            Vertex billRoom = new Vertex("BILLIARD ROOM", "We got a pool table!");
            Vertex gameRoom = new Vertex("GAME ROOM", "A whole room dedicated to just games!");
            Vertex libRoom = new Vertex("LIBRARY ROOM", "An entire room full of books");
            Vertex exitRoom = new Vertex("EXIT ROOM", "You can leave, but with pool, drawing, games, and books - why would you want to?");

            //Adding each vertex to the vertices list
            vertices.Add(drawRoom);
            vertices.Add(billRoom);
            vertices.Add(gameRoom);
            vertices.Add(libRoom);
            vertices.Add(exitRoom);

            //Creating an adjacency list for Drawing Room
            adjacencies[drawRoom.Name] = new List<Vertex>();
            adjacencies[drawRoom.Name].Add(billRoom);
            adjacencies[drawRoom.Name].Add(gameRoom);
            adjacencies[drawRoom.Name].Add(libRoom);

            //Creating an adjacency list for Billiard Room
            adjacencies[billRoom.Name] = new List<Vertex>();
            adjacencies[billRoom.Name].Add(drawRoom);

            //Creating an adjacency list for Game Room
            adjacencies[gameRoom.Name] = new List<Vertex>();
            adjacencies[gameRoom.Name].Add(drawRoom);
            adjacencies[gameRoom.Name].Add(libRoom);

            //Creating an adjacency list for Library Room
            adjacencies[libRoom.Name] = new List<Vertex>();
            adjacencies[libRoom.Name].Add(drawRoom);
            adjacencies[libRoom.Name].Add(gameRoom);
            adjacencies[libRoom.Name].Add(exitRoom);
        }



        // ----- Methods -----

        //GetAdjacentList Method
        public List<Vertex> GetAdjacentList(string room)
        {
            //If the key is valid, the corresponding adjacency list is returned
            if(adjacencies.ContainsKey(room))
            {
                return adjacencies[room];
            }

            //If the key doesn't exist, null is returned
            return null;
        }

        //IsConnected Method
        public bool IsConnected(string currentRoom, string nextRoom)
        {
            //Iterating thorugh all rooms adacent to currentRoom and comparing them to nextRoom
            foreach(Vertex room in adjacencies[currentRoom])
            {
                //If the name of a room adjacent to currentRoom is the same as nextRoom, true is returned
                if (room.Name.Equals(nextRoom))
                {
                    return true;
                }
            }

            //If true hasn't been returned yet, false is returned
            return false;
        }

        //ListAllVertices Method
        public void ListAllVertices()
        {
            //Calling the ToString method of each room in the vertices list
            foreach(Vertex room in vertices)
            {
                Console.WriteLine(room.ToString());
            }
        }

        //GetRoom Method, which takes a string input and calls the ToString Method of the corrsponding room if it exists
        public string GetRoom(string name)
        {
            //Iterating through the vertices list to find the room with the matching name
            foreach(Vertex room in vertices)
            {
                //If a room with the same name is found, its ToString method is returned
                if(room.Name.Equals(name))
                {
                    return room.ToString();
                }
            }

            //If nothing has been returned yet, null is returned
            return null;
        }
    }
}

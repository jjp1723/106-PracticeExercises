using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Searching
{
    class Graph
    {
        // ----- Fields -----
        protected bool[,] matrix;
        protected Dictionary<string, Vertex> dict;
        protected List<Vertex> vertices;



        // ----- Constructor -----
        public Graph()
        {
            //Creating all Vertices
            Vertex a = new Vertex("A");
            Vertex b = new Vertex("B");
            Vertex c = new Vertex("C");
            Vertex d = new Vertex("D");
            Vertex e = new Vertex("E");
            Vertex f = new Vertex("F");
            Vertex g = new Vertex("G");

            //Initializing the matrix and setting every index to false
            matrix = new bool[7, 7];
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    matrix[i, j] = false;
                }
            }

            //Adding data to the matrix based on the vertices' relationships using the Helper method
            Helper(a, b);
            Helper(a, d);
            Helper(a, f);
            Helper(b, c);
            Helper(d, e);
            Helper(f, g);

            //Initializing the dictionary and adding all vertices
            dict = new Dictionary<string, Vertex>();
            dict["A"] = a;
            dict["B"] = b;
            dict["C"] = c;
            dict["D"] = d;
            dict["E"] = e;
            dict["F"] = f;
            dict["G"] = g;

            //Initializing the list and adding all vertices
            vertices = new List<Vertex>();
            vertices.Add(a);
            vertices.Add(b);
            vertices.Add(c);
            vertices.Add(d);
            vertices.Add(e);
            vertices.Add(f);
            vertices.Add(g);
        }



        // ----- Methods -----

        //Helper Method
        public void Helper(Vertex v1, Vertex v2)
        {
            //Creating integer indexes that will represent the vertices
            int index1 = 7;
            int index2 = 7;

            //Assigning a value to index 1 based on the name of the first vertex
            switch(v1.Name)
            {
                case "A":
                    index1 = 0;
                    break;

                case "B":
                    index1 = 1;
                    break;

                case "C":
                    index1 = 2;
                    break;

                case "D":
                    index1 = 3;
                    break;

                case "E":
                    index1 = 4;
                    break;

                case "F":
                    index1 = 5;
                    break;

                case "G":
                    index1 = 6;
                    break;

                //For when the input vertex isn't valid
                default:
                    index1 = 7;
                    break;
            }

            //Assigning a value to index 2 based on the name of the second vertex
            switch (v2.Name)
            {
                case "A":
                    index2 = 0;
                    break;

                case "B":
                    index2 = 1;
                    break;

                case "C":
                    index2 = 2;
                    break;

                case "D":
                    index2 = 3;
                    break;

                case "E":
                    index2 = 4;
                    break;

                case "F":
                    index2 = 5;
                    break;

                case "G":
                    index2 = 6;
                    break;

                //For when the input vertex isn't valid
                default:
                    index2 = 7;
                    break;
            }

            //Only operates for valid vertices
            if(index1 != 7 && index2 != 7)
            {
                //Using the indexes to store relationships in the matrix
                matrix[index1, index2] = true;
                matrix[index2, index1] = true;
            }
        }

        //Reset Method
        public void Reset()
        {
            foreach(Vertex vertex in vertices)
            {
                vertex.Visited = false;
            }
        }

        //GetAdjacentUnvisited Method
        public Vertex GetAdjacentUnvisited(String name)
        {
            //Creating a integer index to represent the name of the vertex
            int index = 0;

            //Assigning a value to the index based on the name
            switch (name)
            {
                case "A":
                    index = 0;
                    break;

                case "B":
                    index = 1;
                    break;

                case "C":
                    index = 2;
                    break;

                case "D":
                    index = 3;
                    break;

                case "E":
                    index = 4;
                    break;

                case "F":
                    index = 5;
                    break;

                case "G":
                    index = 6;
                    break;

                //When the input name isn't valid, null is returned
                default:
                    return null;
            }

            for (int i = 0; i < 7; i++)
            {
                //CHecking whether the vertex with the repected value of "i"
                //  is adjacent to the provided vertex and has not been visited
                if (matrix[index, i] == true && vertices[i].Visited == false)
                {
                    //If the above condition is met, the vertex with the index "i" is returned
                    return vertices[i];
                }
            }

            //If nothing has been returned so far, null is returned
            return null;
        }

        //DepthFirst Method
        public void DepthFirst(string name)
        {
            //Creating a integer index to represent the name of the vertex
            int index = 0;

            //Assigning a value to the index based on the name
            switch (name)
            {
                case "A":
                    index = 0;
                    break;

                case "B":
                    index = 1;
                    break;

                case "C":
                    index = 2;
                    break;

                case "D":
                    index = 3;
                    break;

                case "E":
                    index = 4;
                    break;

                case "F":
                    index = 5;
                    break;

                case "G":
                    index = 6;
                    break;

                //When the input name isn't valid, an error is printed and the method returns
                default:
                    Console.WriteLine("\n\nInvalid Index\n");
                    return;
            }

            //Resetting all vertices
            Reset();

            //Creating a Stack<Vertex> to keep track of the current vertex
            Stack<Vertex> stack = new Stack<Vertex>();

            //Getting the current vertex, printing its name, adding it to the stack, and marking it at visited
            Vertex current = vertices[index];
            Console.WriteLine("\n\nStarting at: " + name);
            stack.Push(current);
            current.Visited = true;

            //Looping while there is something on the stack
            while(stack.Count != 0)
            {
                //Getting an adjacent and unvisited vertex to the vertex on top of the stack
                Vertex adjacent = GetAdjacentUnvisited(stack.Peek().Name);

                //If an adjacent, unvisited vertex was found,
                //  its name is printed, it is added to the stack, and it is marked as visited
                if(adjacent != null)
                {
                    Console.WriteLine(adjacent.Name);
                    stack.Push(adjacent);
                    adjacent.Visited = true;
                }

                //If nothing is found, the vertex on top of the stack is popped off
                else
                {
                    stack.Pop();
                }
            }
        }
    }
}

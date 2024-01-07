using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a graph object
            Graph graph = new Graph();

            //Performing three depth searches
            graph.DepthFirst("C");
            graph.DepthFirst("E");
            graph.DepthFirst("A");



            //Keeps the console window open
            Console.ReadLine();
        }
    }
}

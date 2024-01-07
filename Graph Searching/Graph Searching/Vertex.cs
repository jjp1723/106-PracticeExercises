using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Searching
{
    class Vertex
    {
        // ----- Fields -----
        protected string name;
        protected bool visited;



        // ----- Field Properties -----

        //Name Property
        public string Name
        {
            get
            {
                return name;
            }
        }

        //Visited Property
        public bool Visited
        {
            get
            {
                return visited;
            }
            set
            {
                visited = value;
            }
        }



        // ----- Constructor -----
        public Vertex(string id)
        {
            name = id;
            visited = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Basics
{
    class Vertex
    {
        // ----- Fields -----
        protected string name;
        protected string description;



        // ----- Field Properties -----

        //Name Property
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        //Description Property
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }



        // ----- Constructor ------
        public Vertex(string id, string info)
        {
            name = id;
            description = info;
        }



        // ----- Methods -----

        //ToString Method
        public override string ToString()
        {
            return name + ": " + description;
        }
    }
}

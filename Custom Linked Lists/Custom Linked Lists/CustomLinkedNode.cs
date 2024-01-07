using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Linked_Lists
{
    class CustomLinkedNode<T>
    {
        //Fields
        protected T data;
        protected CustomLinkedNode<T> next;



        //Properties
        //Data Property
        public T Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        //Link Property
        public CustomLinkedNode<T> Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }



        //Constructor
        public CustomLinkedNode()
        {
            data = default;
            next = default;
        }
    }
}

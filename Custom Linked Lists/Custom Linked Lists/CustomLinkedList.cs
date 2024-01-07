using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Linked_Lists
{
    class CustomLinkedList<T>
    {
        //Fields
        protected CustomLinkedNode<T> head;
        protected CustomLinkedNode<T> tail;
        protected int count;



        //Properties
        //Count Property
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }



        //Methods
        //Add Method
        public void Add(T data)
        {
            //Creating CustomLinkNode
            CustomLinkedNode<T> node = new CustomLinkedNode<T>();
            node.Data = data;

            //Linking the node to the head if the head is empty
            if (count == 0)
            {
                head = node;
                tail = node;
            }

            //Linking the node to the current tail, then making the node the new tail
            else
            {
                tail.Next = node;
                tail = tail.Next;
            }

            //Incrementing Count
            count++;
        }

        //GetData Method
        public T GetData(int index)
        {
            //Ensuring a valid index was entered
            if (index < count && index >= 0)
            {
                //Creading a temporary node that will flow through the links of each node
                CustomLinkedNode<T> current = head;

                //Looping through the links of each node to the index
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                //Returning the data at the index
                return current.Data;
            }

            //Throwing an IndexOutOfRangeException if the index is invalid
            else
            {
                throw new System.IndexOutOfRangeException("Invalid index");
            }
        }




        //Constructor
        public CustomLinkedList()
        {
            head = default;
            tail = default;
            count = 0;
        }
    }
}

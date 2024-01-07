using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Linked_Lists_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a CustomLinkedList
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            //Creating a loop that will allow the user to add only 5 items to the CustomLinkedList
            for (int i = 0; i < 6; i++)
            {
                //Prompting the user for input and adding it to the CustomLinkedList
                Console.WriteLine("What are you adding to the list?");
                linkedList.Add(Console.ReadLine());
            }

            //Looping through the CustomLinkedList and returning all data
            Console.WriteLine("\n\n\nHere is your list:\n");
            for (int j = 0; j < linkedList.Count; j++)
            {
                Console.WriteLine(linkedList.GetData(j));
            }

            //Attempting to remove an invalid index
            try
            {
                linkedList.RemoveAt(7);
            }
            catch(Exception e)
            {
                Console.WriteLine("\n\n\n" + e.Message);
            }

            //Deleting the tail node
            Console.WriteLine("Removed " + linkedList.RemoveAt(5) + " from the linked list");

            //Deleting the head node
            Console.WriteLine("Removed " + linkedList.RemoveAt(0) + " from the linked list");

            //Deleting a random node
            Random rng = new Random();
            int index = rng.Next(linkedList.Count);
            Console.WriteLine("Removed " + linkedList.RemoveAt(index) + " from the linked list");

            //Looping through the CustomLinkedList and returning all data
            Console.WriteLine("\n\n\nHere is your list:\n");
            for (int j = 0; j < linkedList.Count; j++)
            {
                Console.WriteLine(linkedList.GetData(j));
            }



            //Keeps the console window open
            Console.ReadLine();
        }
    }
}

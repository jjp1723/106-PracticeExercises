using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Linked_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a CustomLinkedList
            CustomLinkedList<string> linkedList = new CustomLinkedList<string>();

            //Creating a loop that will allow the user to add only 5 items to the CustomLinkedList
            for(int i = 0; i < 5; i++)
            {
                //Prompting the user for input and adding it to the CustomLinkedList
                Console.WriteLine("What are you adding to the list?");
                linkedList.Add(Console.ReadLine());
            }

            //Looping through the CustomLinkedList and returning all data
            Console.WriteLine("\n\n\nHere is your list:\n");
            for(int j = 0; j < 5; j++)
            {
                Console.WriteLine(linkedList.GetData(j));
            }



            //Keeps the console window open
            Console.ReadLine();
        }
    }
}

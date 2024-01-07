using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenges
{
    class Program
    {
        //Problem 1: Dice Sum
        public static void DiceSum()
        {
            //Prompting the user for a desired sum
            int sum = 0;

            //Ensuring user input is a valid number
            while (true)
            {
                Console.WriteLine("Desired dice sum: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out sum))
                {
                    sum = int.Parse(input);

                    if (sum < 2 || sum > 12)
                    {
                        Console.WriteLine("Invalid sum\n");
                    }
                    else
                    {
                        Console.WriteLine("\nRolling dice:\n");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid entry\n");
                }
            }

            //Generating dice rolls until the desired sum is reached
            Random rng = new Random();
            int total = 0;
            while (total != sum)
            {
                int roll1 = rng.Next(6) + 1;
                int roll2 = rng.Next(6) + 1;

                total = roll1 + roll2;

                Console.WriteLine(roll1 + " and " + roll2 + " = " + total);
            }
        }



        //Problem 2: Last First
        public static string LastFirst(string name)
        {
            //Splitting the name and getting the first letter of the last name
            string[] names = name.Split(' ');
            string last = names[0].Substring(0, 1);

            //Returning the names in the desired format (Last, First Initial)
            return (names[1] + ", " + last + ".");
        }



        //Problem 3: Palindromes
        public static bool IsPalindrome(string word)
        {
            //Splitting the word into its individual characters and reassembling them in reverse order
            string reverse = "";
            for(int i = word.Length - 1; i > -1; i--)
            {
                reverse += word.Substring(i, 1);
            }

            //Comparing the word and the reverse and returning a boolean value
            return (word.ToLower().Equals(reverse.ToLower()));
        }



        //Priblem 4: Longest Sorted Sequence
        public static int LongestSortedSequence(int[] numArray)
        {
            int sequence = 1;

            //Looping through each item in the array to compare it to other items
            for(int i = 0; i < numArray.Length - 2; i++)
            {
                int newSequence = 1;

                //Looping through every item after index i to see if a sequence forms
                for(int j = i + 1; j < numArray.Length - 1; j++)
                {
                    //If a sequence does form, the value of the new sequence and the index i is incremented
                    if(numArray[i] <= numArray[j])
                    {
                        newSequence++;
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }

                //Comparing the new sequence to the current longest sequence, if the new sequence is greater, it replaces the old one
                if(newSequence > sequence)
                {
                    sequence = newSequence;
                }
            }

            //Returning the longest sorted sequence
            return sequence;
        }



        //Problem 5: Get Longest Duplicate
        public static int GetLongestDuplicateChain(int[] numArray)
        {
            int chain = 1;
            int numChain = 0;

            //Looping through each item in the array to compare it to other items
            for (int i = 0; i < numArray.Length - 2; i++)
            {
                int newChain = 1;
                int newChainNum = numArray[0];

                //Looping through every item after index i to see if a sequence forms
                for (int j = i + 1; j < numArray.Length - 1; j++)
                {
                    //If a sequence does form, the value of the new sequence and the index i is incremented
                    if (numArray[i] == numArray[j])
                    {
                        newChain++;
                        newChainNum = numArray[i];
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }

                //Comparing the new sequence to the current longest sequence, if the new sequence is greater, it replaces the old one
                if (newChain > chain || (newChain == chain && newChainNum > numChain))
                {
                    chain = newChain;
                    numChain = newChainNum;
                }
            }

            //Returning the longest sorted sequence
            return numChain;
        }




        //Main Method
        static void Main(string[] args)
        {
            //Dice Sum
            DiceSum();
            Console.ReadLine();

            //Last First
            Console.WriteLine("\n" + LastFirst("Wedge Antilles"));
            Console.ReadLine();

            //Palindromes
            Console.WriteLine("\n" + IsPalindrome("Tacocat"));
            Console.WriteLine("\n" + IsPalindrome("happy birthday"));
            Console.ReadLine();

            //Longest Sorted Sequence
            int[] array1 = {3, 8, 10, 1, 9, 14, -3, 0, 14, 207, 56, 98};
            int[] array2 = {17, 42, 3, 5, 5, 5, 8, 2, 4, 6, 1, 19};
            Console.WriteLine("\n" + LongestSortedSequence(array1));
            Console.WriteLine("\n" + LongestSortedSequence(array2));
            Console.ReadLine();

            //Get Longest Duplicate
            int[] array3 = {2, 2, 4, 10, 10, 10, 10, 4, 2, 2, 2, 4};
            int[] array4 = { 5, 2, 4, 4, 6, 6, 6, 7, 7, 7, 1, 2 };
            Console.WriteLine("\n" + GetLongestDuplicateChain(array3));
            Console.WriteLine("\n" + GetLongestDuplicateChain(array4));



            //Keeps Console Window Open
            Console.ReadLine();
        }
    }
}

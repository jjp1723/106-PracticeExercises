using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent_Tree_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating seven TalentTree nodes that will be linked together in a TalentTree of depth 3
            TalentTree magic = new TalentTree("Magic", true);
            TalentTree fireball = new TalentTree("Fireball", true);
            TalentTree magicArrow = new TalentTree("Magic Arrow", true);
            TalentTree crazyBigFireball = new TalentTree("Crazy Big Fireball", true);
            TalentTree thousandTinyFireballs = new TalentTree("1000 Tiny Fireballs", false);
            TalentTree iceArrow = new TalentTree("Ice Arrow", true);
            TalentTree explodingArrow = new TalentTree("Exploding Arrow", false);

            //Linking all seven TalentTree nodes into a Talentree of depth 3
            magicArrow.LeftChild = iceArrow;
            magicArrow.RightChild = explodingArrow;
            fireball.LeftChild = crazyBigFireball;
            fireball.RightChild = thousandTinyFireballs;
            magic.LeftChild = fireball;
            magic.RightChild = magicArrow;

            //Calling the ListAllAbilities method for magic (the head node)
            Console.WriteLine("List of all abilities:");
            magic.ListAllAbilities();

            //Calling the ListKnownAbilities method for magic (the head node)
            Console.WriteLine("\n\n\nList of all known abilities:");
            magic.ListKnownAbilities();

            //Calling the ListPossibleAbilities method for magic (the head node)
            Console.WriteLine("\n\n\nList of all possible abilities to still learn:");
            magic.ListPossibleAbilities();



            //Keeping the console window open
            Console.ReadLine();
        }
    }
}

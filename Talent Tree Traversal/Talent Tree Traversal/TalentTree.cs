using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent_Tree_Traversal
{
    class TalentTree
    {
        //Fields
        protected string name;
        protected bool learned;
        protected TalentTree leftChild;
        protected TalentTree rightChild;



        //Field Properties

        //LeftChild Property
        public TalentTree LeftChild
        {
            get
            {
                return leftChild;
            }
            set
            {
                leftChild = value;
            }
        }

        //RightChild Property
        public TalentTree RightChild
        {
            get
            {
                return rightChild;
            }
            set
            {
                rightChild = value;
            }
        }



        //Constructor
        public TalentTree(string id, bool know)
        {
            name = id;
            learned = know;
        }



        //Methods

        //ListAllAbilities Method
        public void ListAllAbilities()
        {
            //Calling this method for the left child if it exists
            if(leftChild != null)
            {
                leftChild.ListAllAbilities();
            }

            //Printing this one
            Console.WriteLine(name);

            //Calling this method for the right child if it exists
            if(rightChild != null)
            {
                rightChild.ListAllAbilities();
            }
        }

        //ListKnownAbilities Method
        public void ListKnownAbilities()
        {
            //Checking if this node has been learned
            if(learned)
            {
                //Ptrinting this node's ability
                Console.WriteLine(name);

                //Calling this method for the left child if it exists
                if(leftChild != null)
                {
                    leftChild.ListKnownAbilities();
                }

                //Calling this method for the right child if it exists
                if(rightChild != null)
                {
                    rightChild.ListKnownAbilities();
                }
            }
        }

        //ListPossibleAbilities Method
        public void ListPossibleAbilities()
        {
            //Checking if this node has been learned
            if (learned)
            {
                //Calling this method for the left child if it exists
                if (leftChild != null)
                {
                    leftChild.ListPossibleAbilities();
                }

                //Calling this method for the right child if it exists
                if (rightChild != null)
                {
                    rightChild.ListPossibleAbilities();
                }
            }

            //If this node has not been learned, it is printed
            else
            {
                Console.WriteLine(name);
            }
        }
    }
}

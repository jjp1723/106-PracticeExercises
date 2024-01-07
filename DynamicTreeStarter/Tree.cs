using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynamicTreeStarter
{
	/// <summary>
	/// Represents a tree-centric data structure
	/// that can have data dynamically inserted, 
	/// and can be drawn as a literal "tree" on the screen
	/// </summary>
	class Tree : DrawableTree
	{
		// Already has an inherited root node field called "root"

		/// <summary>
		/// Creates a tree that can be drawn
		/// </summary>
		/// <param name="sb">The sprite batch used to draw</param>
		/// <param name="treeColor">The color of this tree</param>
		public Tree(SpriteBatch sb, Color treeColor)
			: base(sb, treeColor)
		{ }

		/// <summary>
		/// Public facing Insert method
		/// </summary>
		/// <param name="data">The data to insert</param>
		public void Insert(int data)
		{
			//If there isn't a root, a TreeNode is created with the data and becomes the root
			if(root == null)
			{
				root = new TreeNode(data);
			}

			//If there is a root, the recurive insert method is called from the root
			else
			{
				Insert(data, root);
			}
		}

		/// <summary>
		/// Private recursive insert method
		/// </summary>
		/// <param name="data">The data to insert</param>
		/// <param name="node">The node to attempt to insert into</param>
		private void Insert(int data, TreeNode node)
		{
			//Determining if the data being inserted is less than the data stored in the node
			if(data < node.Data)
			{
				//If the data being inserted is less than the data stored in the node,
				//	it checks if the node's left field is empty
				if(node.Left == null)
				{
					//If the node's left field is empty, a new node is created with the data and stored there
					node.Left = new TreeNode(data);
				}

				//If the node's left field isn't empty, the recursive insert method is called from the left field
				else
				{
					Insert(data, node.Left);
				}
			}

			//Determining if the data being inserted is greater than the data stored in the node
			else if (data >= node.Data)
			{
				//If the data being inserted is greater than the data stored in the node,
				//	it checks if the node's right field is empty
				if (node.Right == null)
				{
					//If the node's right field is empty, a new node is created with the data and stored there
					node.Right = new TreeNode(data);
				}

				//If the node's right field isn't empty, the recursive insert method is called from the right field
				else
				{
					Insert(data, node.Right);
				}
			}
		}
	}
}

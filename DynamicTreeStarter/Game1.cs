using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace DynamicTreeStarter
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		// The three trees
		Tree treeRed;
		Tree treeGreen;
		Tree treeBlue;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			//Change the window size
			graphics.PreferredBackBufferWidth = 1000;
			graphics.PreferredBackBufferHeight = 1000;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// Create the three trees
			treeRed = new Tree(spriteBatch, Color.Red);
			treeGreen = new Tree(spriteBatch, Color.Green);
			treeBlue = new Tree(spriteBatch, Color.DodgerBlue);

			//Creating a Random object to help insert values
			Random rng = new Random();

			//Filling in the red tree by inserting a value and using the random to generate numbers
			//	in a given range where the root is in the middle
			treeRed.Insert(25);
			for (int repeat = 0; repeat < 100; repeat++)
			{
				treeRed.Insert(rng.Next(51));
			}

            //Filling in the blue tree by inserting a value and using the random to generate numbers
            //	in a given range where the previous number is in the lower end of the range of possible calculated numbers
            int tempNum = 23;
			treeBlue.Insert(tempNum);
			for(int repeat = 0; repeat < 100; repeat++)
			{
                tempNum = rng.Next(tempNum - 23, tempNum + 28);
                treeBlue.Insert(tempNum);
			}

			//Filling in the green tree by inserting a value and using the random to generate numbers
			//	in a given range where the root is the absolute minimum
			treeGreen.Insert(1);
			for (int repeat = 0; repeat < 100; repeat++)
			{
				treeGreen.Insert(1);
			}
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// After you have the rest of the assignment working:
			//  What happens if you insert a new piece of 
			//  data into the trees each frame?

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			// Draw the trees
			treeRed.Draw(new Vector2(200, 400));
			treeGreen.Draw(new Vector2(400, 400));
			treeBlue.Draw(new Vector2(600, 400));

			base.Draw(gameTime);
		}
	}
}

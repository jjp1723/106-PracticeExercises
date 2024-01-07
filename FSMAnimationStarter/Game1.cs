using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FSMAnimationStarter
{
	//Creating Enum for the Sprite State
	enum MarioState
	{
		standRight,
		standLeft,
		runRight,
		runLeft
	}

	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		// Mario texture fields
		private Texture2D marioTexture;
		private Vector2 marioPosition;

		// Sprite-sheet related fields
		private int numSpritesInSheet;
		private int widthOfSingleSprite;

		// Animation related fields
		private double fps;
		private double secondsPerFrame;
		private double timeCounter;
		private int currentFrame;

		// Sprite-State related fields
		private MarioState currentState;
		private MarioState previousState;


		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}



		//ProcessInput Method
		protected void ProcessInput()
		{
			//Storing the keyoard's current state in a temporary variable
			KeyboardState tempState = Keyboard.GetState();

			//Using 4 if statements to check if the 2 arrow keys are pressed and moving mario accordingly
			//	If no keys are pressed, the previous state is checked
			if (tempState.IsKeyDown(Keys.Right))
			{
				//Moves Mario right and sets the current and previous states
				marioPosition.X += 5;
				currentState = MarioState.runRight;
				previousState = MarioState.runRight;
			}
			else if (tempState.IsKeyDown(Keys.Left))
			{
				//Moves Mario left and sets the current and previous states
				marioPosition.X -= 5;
				currentState = MarioState.runLeft;
				previousState = MarioState.runLeft;
			}
			else if (previousState == MarioState.runRight)
			{
				//If mario's previous state was runRight, he remains stationary while facing right
				currentState = MarioState.standRight;
			}
			else
			{
				//If mario's previous state was runLeft, he remains stationary while facing left
				currentState = MarioState.standLeft;
			}
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

			// Load assets
			marioTexture = Content.Load<Texture2D>("MarioSpriteSheet");
			marioPosition = new Vector2(200, 200);

			// How many sprites in the sheet?
			numSpritesInSheet = 4;
			widthOfSingleSprite = marioTexture.Width / numSpritesInSheet;

			// Set up animation data
			fps = 10;
			secondsPerFrame = 1.0 / fps;
			timeCounter = 0;
			currentFrame = 1;

			// Set up the current and previous sprite state
			currentState = MarioState.standRight;
			previousState = MarioState.standRight;
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

			// Using ProcessInput to determing the MarioState and move mario
			ProcessInput();

			//Checks whether the current state is one of the two runs and animates mario if it is
			if(currentState == MarioState.runRight || currentState == MarioState.runLeft)
			{
				UpdateAnimation(gameTime);
			}
			
			base.Update(gameTime);
		}

		private void UpdateAnimation(GameTime gt)
		{
			// Add to the time counter (using TOTAL SECONDS)
			timeCounter += gt.ElapsedGameTime.TotalSeconds;

			// Is it time to swap frames?
			if (timeCounter >= secondsPerFrame)
			{
				// Swap frames
				currentFrame++;
				if (currentFrame > 3)
					currentFrame = 1;

				// Remove one "frame" worth of time
				// from the counter
				timeCounter -= secondsPerFrame;
			}
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			spriteBatch.Begin();

			//Using switch to draw the sprite based on the current state
			switch (currentState)
			{
				case MarioState.standRight:
					DrawMarioStanding(SpriteEffects.None);
					break;

				case MarioState.standLeft:
					DrawMarioStanding(SpriteEffects.FlipHorizontally);
					break;

				case MarioState.runRight:
					DrawMarioWalking(SpriteEffects.None);
					break;

				case MarioState.runLeft:
					DrawMarioWalking(SpriteEffects.FlipHorizontally);
					break;
			}

			spriteBatch.End();

			base.Draw(gameTime);
		}

		private void DrawMarioStanding(SpriteEffects flip)
		{
			spriteBatch.Draw(
				marioTexture, 
				marioPosition,
				new Rectangle(0, 0, widthOfSingleSprite, marioTexture.Height),
				Color.White,
				0.0f,
				Vector2.Zero,
				Vector2.One,
				flip,
				0);

		}

		private void DrawMarioWalking(SpriteEffects flip)
		{
			spriteBatch.Draw(
				marioTexture,
				marioPosition,
				new Rectangle(
					widthOfSingleSprite * currentFrame, 
					0, 
					widthOfSingleSprite, 
					marioTexture.Height),
				Color.White,
				0.0f,
				Vector2.Zero,
				Vector2.One,
				flip,
				0);

		}
	}
}

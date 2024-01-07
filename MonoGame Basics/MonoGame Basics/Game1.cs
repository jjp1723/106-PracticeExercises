using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Basics
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Creating related fields
        private Texture2D meatballTexture;
        private Vector2 meatballPosition;
        private int direction;
        private Texture2D earthTexture;
        private Rectangle earthRectangle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Change the window size
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 600;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Initialize the Meatball Position
            meatballPosition = new Vector2(10, 10);

            //Initialize the direction
            direction = 1;

            //Initialize the Meatball Rectangle in a centerec position
            earthRectangle = new Rectangle(graphics.PreferredBackBufferWidth / 2 - 30, graphics.PreferredBackBufferHeight / 2 - 30, 60, 60);

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

            //Load the Meatball Man
            meatballTexture = Content.Load<Texture2D>("MeatballMan");

            //Load the Earth
            earthTexture = Content.Load<Texture2D>("Earth");
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

            //Move the Meatball Man right until he touches the right border
            if(direction == 1 && meatballTexture.Width + meatballPosition.X < graphics.PreferredBackBufferWidth)
            {
                meatballPosition.X += 0.05f * direction;
            }

            //Move the Meatball Man left until he touches the left border
            else if(direction == -1 && meatballPosition.X > -1)
            {
                meatballPosition.X += 0.05f * direction;
            }

            //Changing the direction of the Meatball man
            else
            {
                direction *= -1;
            }
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            //Start the sprite batch
            spriteBatch.Begin();

            //Draw the moving Meatball Man
            spriteBatch.Draw(meatballTexture, meatballPosition, Color.Gray);

            //Draw the stationary Meatball Man
            spriteBatch.Draw(earthTexture, earthRectangle, Color.DarkRed);

            //End the sprite batch
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

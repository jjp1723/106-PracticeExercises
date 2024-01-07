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

        private SpriteFont text;
        private Button button;
        private Texture2D chrome;
        private Texture2D explore;
        private MouseState mouse;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Change the window size
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 600;
        }



        //ProcessInput Method
        protected void ProcessInput()
        {
            //Storing the keyoard's current state in a temporary variable
            KeyboardState tempState = Keyboard.GetState();

            //Using 4 if statements to check if the 4 arrow keys are pressed,
            //  and moving ths stationary image accordingly
            if(tempState.IsKeyDown(Keys.Down))
            {
                earthRectangle.Y += 5;
            }
            if (tempState.IsKeyDown(Keys.Up))
            {
                earthRectangle.Y -= 5;
            }
            if (tempState.IsKeyDown(Keys.Right))
            {
                earthRectangle.X += 5;
            }
            if (tempState.IsKeyDown(Keys.Left))
            {
                earthRectangle.X -= 5;
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
            //Initialize the Meatball Position
            meatballPosition = new Vector2(10, 10);

            //Initialize the direction
            direction = 1;

            //Initialize the Earth Rectangle in a centered position
            earthRectangle = new Rectangle(graphics.PreferredBackBufferWidth / 2 - 30, graphics.PreferredBackBufferHeight / 2 - 30, 60, 60);

            //Initializing the Button
            chrome = Content.Load<Texture2D>("Google Chrome");
            explore = Content.Load<Texture2D>("Internet Explorer");
            button = new Button(explore, chrome, new Rectangle(500, 500, 100, 100));

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

            //Load the Text
            text = Content.Load<SpriteFont>("Font");

            //Load the Chrome
            chrome = Content.Load<Texture2D>("Google Chrome");

            //Load the Explore
            explore = Content.Load<Texture2D>("Internet Explorer");
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

            //Calling the ProcessInput Method
            ProcessInput();

            //Uptating the mouse state
            mouse = Mouse.GetState(this.Window);

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

            //Draw the stationary Earh
            spriteBatch.Draw(earthTexture, earthRectangle, Color.DarkRed);

            //Draw the text of my name
            spriteBatch.DrawString(text, "John Pionzio was here", new Vector2(0,0), Color.White);

            //Draw the text of the Meatball Man's position
            spriteBatch.DrawString(text, ("Meatball Man Location    X: " + meatballPosition.X + "    Y: " + meatballPosition.Y), new Vector2(0, 20), Color.White);

            //Draw the Button
            button.Draw(spriteBatch, mouse);

            //Draw the text of the mouse's position
            spriteBatch.DrawString(text, ("Mouse Location   X: " + mouse.X + "   Y: " + mouse.Y), new Vector2(0, 40), Color.White);

            //End the sprite batch
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

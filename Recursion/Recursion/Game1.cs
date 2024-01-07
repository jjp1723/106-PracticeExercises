using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Recursion
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Related Fields
        Texture2D image;
        SpriteFont text;



        //DrawRecursiveThing Method
        public int DrawRecursiveThing(int x, int y,int width, int height, Color color, SpriteBatch sb)
        {
            //Establishing an int variable that will be returned at the end
            int count = 1;

            //Drawing the image
            sb.Draw(image, new Rectangle(x, y, width, height), color);

            //Determining is another image should be drawn based on the width and height of the current image
            if(width > 20 && height > 20)
            {
                //Determining the color of the next image
                Color nextColor = Color.White;
                if (color == Color.White)
                {
                    nextColor = Color.Red;
                }

                //Using recursion to draw another image in the upper left corner of the current image and incrementing cout
                count += DrawRecursiveThing(x, y, width / 2, height / 2, nextColor, sb);

                //Using recursion to draw another image in the upper right corner of the current image and incrementing count
                count += DrawRecursiveThing(x + width / 2, y + height / 2, width / 2, height / 2, nextColor, sb);
            }

            //Returning count
            return count;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Changing the size of the viewport
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 1200;
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

            //Loading the image texture
            image = Content.Load<Texture2D>("Meatball Man");

            //Loading the text spritefont
            text = Content.Load<SpriteFont>("Text");
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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Beginning the Sprite Batch
            spriteBatch.Begin();

            //Calling DrawRecursiveThing
            int count = DrawRecursiveThing(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, Color.White, spriteBatch);

            //Drawing the count on the widow
            spriteBatch.DrawString(text, "Count: " + count, new Vector2(1200, 0), Color.White);

            //Ending the Sprite Batch
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

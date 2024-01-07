using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario_Finite_State_Machine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Mario-Texture Related Fields
        private Texture2D marioTexture;
        private Vector2 marioPosition;

        //Sprite-Sheet Related Fields
        private int spriteNum;
        private int spriteHeight;
        private int spriteWidth;

        //Frame Related Fields
        private int secondsPerFrame;
        private int currentFrame;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            // TODO: use this.Content to load your game content here
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

            //Updateing the finite state of the sprite
            UpdateAnimation(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Begining the sprite batch
            spriteBatch.Begin();

            //Draw
            DrawMarioStandingLeft(SpriteEffects.FlipHorizontally);

            //Ending the sprite batch
            spriteBatch.End();

            base.Draw(gameTime);
        }



        //UpdateAnimation Method
        private void UpdateAnimation(GameTime time)
        {

        }



        //DrawMarioStanding Method
        private void DrawMarioStanding()
        {
            spriteBatch.Draw(marioTexture, marioPosition, new Rectangle(0, 0, spriteWidth, spriteHeight), Color.White);
        }



        //DrawMarioStandingLeft Method
        private void DrawMarioStandingLeft(SpriteEffects flip)
        {
            spriteBatch.Draw(marioTexture, marioPosition, new Rectangle(0, 0, spriteWidth, spriteHeight), Color.White, 0.0f, Vector2.Zero, Vector2.One, flip, 0);
        }



        //DrawMarioWalking Method
        private void DrawMarioWalking()
        {

        }



        //DrawMarioWalkingLeft Method
        private void DrawMarioWalkingLeft(SpriteEffects flip)
        {

        }
    }
}

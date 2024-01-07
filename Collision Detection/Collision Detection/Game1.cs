using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Collision_Detection
{
    //Creating Enum for the Game State
    enum ShapeState
    {
        squareState,
        circleState
    }



    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //SquareEntity Related Fields
        private Texture2D squareTexture;
        private SquareEntity playerSquare;
        private List<SquareEntity> squareList;

        //CircleEntity Related Fields
        private Texture2D circleTexture;
        private CircleEntity playerCircle;
        private List<CircleEntity> circleList;

        //GameState Related Fields
        private ShapeState state;

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



            //Checking if the player presses 1 or 2 and changing the game state accordingly
            if(tempState.IsKeyDown(Keys.D1))
            {
                state = ShapeState.squareState;
            }
            else if(tempState.IsKeyDown(Keys.D2))
            {
                state = ShapeState.circleState;
            }



            //Using 4 if statements to check if the 4 arrow keys are pressed,
            //  and moving ths PlayerSquare or PlayerCircle image accordingly
            if (tempState.IsKeyDown(Keys.Down))
            {
                playerSquare.Y += 5;
                playerCircle.Y += 5;
            }
            if (tempState.IsKeyDown(Keys.Up))
            {
                playerSquare.Y -= 5;
                playerCircle.Y -= 5;
            }
            if (tempState.IsKeyDown(Keys.Right))
            {
                playerSquare.X += 5;
                playerCircle.X += 5;
            }
            if (tempState.IsKeyDown(Keys.Left))
            {
                playerSquare.X -= 5;
                playerCircle.X -= 5;
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
            //Setting the innitial ShapeState to SquareState
            state = ShapeState.squareState;

            //Creating a Random object
            Random rng = new Random();

            //Load the squareTexture
            squareTexture = Content.Load<Texture2D>("square");

            //Initialize the PlayerSquare
            playerSquare = new SquareEntity(squareTexture, 50, 50, 50, 50);
            
            //Load the circleTexture
            circleTexture = Content.Load<Texture2D>("circle");

            //Initialize the PlayerCircle
            playerCircle = new CircleEntity(circleTexture, 50, 50, 25);

            //Initializing the SquareList and CircleList
            squareList = new List<SquareEntity>();
            circleList = new List<CircleEntity>();

            //Adding items to the SquareList and CircleList
            for (int repeat = 0; repeat < 10; repeat++)
            {
                //Generating a new SquareEntity with random x, y, widht, and height values and adding it to the SquareList
                SquareEntity newSquare = new SquareEntity(squareTexture, rng.Next(575), rng.Next(575), rng.Next(46) + 5, rng.Next(46) + 5);
                squareList.Add(newSquare);

                //Generating a new CircleEntity with random x, y, and radius values and adding it to the CircleList
                CircleEntity newCircle = new CircleEntity(circleTexture, rng.Next(575), rng.Next(575), rng.Next(26) + 3);
                circleList.Add(newCircle);
            }

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

            //Load the squareTexture
            squareTexture = Content.Load<Texture2D>("square");
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

            //Calling the ProcessInput Method
            ProcessInput();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //Beginthe sprite batch
            spriteBatch.Begin();

            //Checking the ShapeState and drawing accordingly
            //  Drawing Code for SquareState
            if(state == ShapeState.squareState)
            {
                //Draw the squares in the SquareList
                foreach (SquareEntity square in squareList)
                {
                    square.Draw(spriteBatch, Color.White);
                }

                //Creating a boolean to remember whether the player square is intersecting another square
                bool intersecting = false;

                //Calling the Intersects method for all squares in the SquareList
                foreach (SquareEntity square in squareList)
                {

                    if (playerSquare.Intersects(square))
                    {
                        //Draw the PlayerSquare with a red tint
                        playerSquare.Draw(spriteBatch, Color.Red);

                        //Draw the other square with a red tint
                        square.Draw(spriteBatch, Color.Red);

                        //Setting the boolean Intersecting to True
                        intersecting = true;
                    }
                    else
                    {
                        //Making sure to not change the color of the player square if it is intersecting another square
                        if (intersecting)
                        {
                            //Draw the PlayerSquare with a red tint
                            playerSquare.Draw(spriteBatch, Color.Red);
                        }
                        else
                        {
                            //Draw the PlayerSquare with a blue tint
                            playerSquare.Draw(spriteBatch, Color.Blue);
                        }

                        //Draw the other square with a white tint
                        square.Draw(spriteBatch, Color.White);
                    }
                }
            }



            //  Drawing Code for CircleState
            else if(state == ShapeState.circleState)
            {
                //Draw the circles in the CircleList
                foreach (CircleEntity circle in circleList)
                {
                    circle.Draw(spriteBatch, Color.White);
                }

                //Creating a boolean to remember whether the player circle is intersecting another circle
                bool intersecting = false;

                //Calling the Intersects method for all circles in the CircleList
                foreach (CircleEntity circle in circleList)
                {

                    if (playerCircle.Intersects(circle))
                    {
                        //Draw the PlayerSquare with a red tint
                        playerCircle.Draw(spriteBatch, Color.Red);

                        //Draw the other square with a red tint
                        circle.Draw(spriteBatch, Color.Red);

                        //Setting the boolean Intersecting to True
                        intersecting = true;
                    }
                    else
                    {
                        //Making sure to not change the color of the player square if it is intersecting another square
                        if (intersecting)
                        {
                            //Draw the PlayerSquare with a red tint
                            playerCircle.Draw(spriteBatch, Color.Red);
                        }
                        else
                        {
                            //Draw the PlayerSquare with a blue tint
                            playerCircle.Draw(spriteBatch, Color.Blue);
                        }

                        //Draw the other square with a white tint
                        circle.Draw(spriteBatch, Color.White);
                    }
                }
            }
            



            //End the sprite batch
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

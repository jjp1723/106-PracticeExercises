using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Basics
{
    class Button
    {
        //Fields
        protected Texture2D image1;
        protected Texture2D image2;
        protected Rectangle rect;



        //Constructor
        public Button(Texture2D img1, Texture2D img2, Rectangle rectangle)
        {
            image1 = img1;
            image2 = img2;
            rect = rectangle;
        }



        //Draw Method
        public void Draw(SpriteBatch sb, MouseState mouseState)
        {
            //Getting the current state of the mouse and determining whether it is over the button
            if (mouseState.X > rect.X && mouseState.X < rect.X + rect.Width && 
                mouseState.Y > rect.Y && mouseState.Y < rect.Y + rect.Height)
            {
                //If the mouse is over the button, image2 is displayed
                sb.Draw(image2, rect, Color.White);
            }
            else
            {
                //If the mouse is not over the button, image1 is displayed
                sb.Draw(image1, rect, Color.White);
            }
        }
    }
}

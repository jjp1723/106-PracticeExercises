using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Collision_Detection
{
    class SquareEntity
    {
        //Fields
        protected Texture2D squareTexture;
        protected Rectangle squareRectangle;

        //X Property
        public int X
        {
            get
            {
                return squareRectangle.X;
            }
            set
            {
                squareRectangle.X = value;
            }
        }

        //Y Property
        public int Y
        {
            get
            {
                return squareRectangle.Y;
            }
            set
            {
                squareRectangle.Y = value;
            }
        }

        //Constructor
        public SquareEntity(Texture2D image, int x, int y, int width, int height)
        {
            squareTexture = image;
            squareRectangle = new Rectangle(x, y, width, height);
        }



        // --------------- Methods ---------------

        //Intersects Method
        public bool Intersects(SquareEntity other)
        {
            return squareRectangle.Intersects(other.squareRectangle);
        }

        //Draw Method
        public void Draw(SpriteBatch sb, Color tint)
        {
            sb.Draw(squareTexture, squareRectangle, tint);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Collision_Detection
{
    class CircleEntity
    {
        //Fields
        protected Texture2D circleTexture;
        protected Rectangle circleRectangle;
        protected int radius;

        //X Property
        public int X
        {
            get
            {
                return circleRectangle.X + radius;
            }
            set
            {
                circleRectangle.X = value - radius;
            }
        }

        //Y Property
        public int Y
        {
            get
            {
                return circleRectangle.Y + radius;
            }
            set
            {
                circleRectangle.Y = value - radius;
            }
        }

        //Radius Property
        public int Radius
        {
            get
            {
                return radius;
            }
        }

        //Constructor
        public CircleEntity(Texture2D image, int x, int y, int rad)
        {
            circleTexture = image;
            circleRectangle = new Rectangle(x, y, rad * 2, rad * 2);
            radius = rad;
        }



        // --------------- Methods ---------------

        //Intersects Method
        public bool Intersects(CircleEntity other)
        {
            //Calculating the distance between the two circles' x-coordinate
            double dx = Math.Abs(this.X - other.X);

            //Calculating the distance between the two circles' y-coordinate
            double dy = Math.Abs(this.Y - other.Y);

            //Getting the distance using the x and y distances
            double distance = Math.Sqrt(dx * dx + dy * dy);

            //Returning whether the distance is lower than the two radii added together
            return (distance < this.Radius + other.Radius);
        }

        //Draw Method
        public void Draw(SpriteBatch sb, Color tint)
        {
            sb.Draw(circleTexture, circleRectangle, tint);
        }
    }
}

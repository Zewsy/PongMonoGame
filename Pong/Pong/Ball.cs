using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Ball
    {
        public double X { get; set; }
        public double Y { get; set; }
        public bool goesLeft { get; set; } = true;
        public bool goesDown { get; set; } = false;

        public const int SPEED_CONST = 8;
        public double bounceAngle { get; set; } = 0;

        //Velocities
        public double vx { get; set; } = SPEED_CONST;
        public double vy { get; set; } = 0;

        public Texture2D texture { get; set; }

        public void Move()
        {
            if (goesLeft)
            {
                X -= vx;
            }
            else
            {
                X += vx;
            }
            if (goesDown)
            {
                Y += vy;
            }
            else
            {
                Y -= vy;
            }
        }
    }
}

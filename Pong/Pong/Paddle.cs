using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Paddle
    {
        public double X { get; set; }
        public double Y { get; set; }
        private const double MAXANGLE = 5 * Math.PI / 12;

        public Texture2D texture { get; set; }

        public void hitBall(Ball ball, bool horizontal)
        {
            if (!horizontal)
            {
                var relIntersectY = (Y + texture.Height / 2) - (ball.Y);
                var normalizedIntersectY = relIntersectY / (texture.Height / 2);
                ball.bounceAngle = normalizedIntersectY * MAXANGLE;
                ball.vx = Ball.SPEED_CONST * Math.Cos(ball.bounceAngle);
                ball.vy = Ball.SPEED_CONST * -Math.Sin(ball.bounceAngle);
            }
            else
            {
                ball.bounceAngle = Math.PI / 4;
                ball.vy = Ball.SPEED_CONST * Math.Sin(ball.bounceAngle);
                ball.vx = Ball.SPEED_CONST * Math.Cos(ball.bounceAngle);
            }
        }

        public bool checkCollosion(Ball ball)
        {
            if (ball.Y + ball.texture.Width >= Y && ball.Y <= Y + texture.Height)
            {
                hitBall(ball, false);
                return true;
            }
            else
                return false;
        }
    }
}

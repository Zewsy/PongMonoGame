using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Paddle leftPaddle;
        private Paddle rightPaddle;
        private Paddle upFrame;
        private Paddle downFrame;
        private Ball ball;
        private const int MOVEMENT = 3;

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
            leftPaddle = new Paddle();
            rightPaddle = new Paddle();
            upFrame = new Paddle();
            downFrame = new Paddle();
            ball = new Ball();

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

            leftPaddle.texture = Content.Load<Texture2D>("Pong_graphics/left_paddle");
            rightPaddle.texture = Content.Load<Texture2D>("Pong_graphics/right_paddle");
            ball.texture = Content.Load<Texture2D>("Pong_graphics/ball");
            upFrame.texture = Content.Load<Texture2D>("Pong_graphics/frame");
            downFrame.texture = Content.Load<Texture2D>("Pong_graphics/frame");

            upFrame.X = 0;
            upFrame.Y = 0;
            downFrame.X = 0;
            downFrame.Y = graphics.PreferredBackBufferHeight - downFrame.texture.Height;
            leftPaddle.X = 0;
            leftPaddle.Y = graphics.PreferredBackBufferHeight / 2 - leftPaddle.texture.Height / 2;
            rightPaddle.X = graphics.PreferredBackBufferWidth - rightPaddle.texture.Width;
            rightPaddle.Y = graphics.PreferredBackBufferHeight / 2 - rightPaddle.texture.Height / 2;
            ball.X = graphics.PreferredBackBufferWidth / 2;
            ball.Y = graphics.PreferredBackBufferHeight / 2;
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

            // TODO: Add your update logic here
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Down))
            {
                leftPaddle.Y += MOVEMENT;
            }
            else if (state.IsKeyDown(Keys.Up))
            {
                leftPaddle.Y -= MOVEMENT;
            }
            if (state.IsKeyDown(Keys.W))
            {
                rightPaddle.Y -= MOVEMENT;
            }
            else if (state.IsKeyDown(Keys.S))
            {
                rightPaddle.Y += MOVEMENT;
            }

            ball.Move();
            checkCollosions();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(leftPaddle.texture, new Rectangle((int)leftPaddle.X, (int)leftPaddle.Y, leftPaddle.texture.Width, leftPaddle.texture.Height), Color.White);
            spriteBatch.Draw(rightPaddle.texture, new Rectangle((int)rightPaddle.X, (int)rightPaddle.Y, rightPaddle.texture.Width, rightPaddle.texture.Height), Color.White);
            spriteBatch.Draw(ball.texture, new Rectangle((int)ball.X, (int)ball.Y, ball.texture.Width, ball.texture.Height), Color.White);
            spriteBatch.Draw(upFrame.texture, new Rectangle((int)upFrame.X, (int)upFrame.Y, graphics.PreferredBackBufferWidth, upFrame.texture.Height), Color.White);
            spriteBatch.Draw(downFrame.texture, new Rectangle((int)downFrame.X, (int)downFrame.Y, graphics.PreferredBackBufferWidth, downFrame.texture.Height), Color.White);
            spriteBatch.End();
            

            base.Draw(gameTime);
        }

       public void checkCollosions()
        {
            if (ball.X <= leftPaddle.X + leftPaddle.texture.Width + 0.01)
            {
                if (!leftPaddle.checkCollosion(ball))
                    this.Exit();
                else
                    ball.goesLeft = false;
            }
            else if (ball.X >= rightPaddle.X - rightPaddle.texture.Width / 2)
            {
                if (!rightPaddle.checkCollosion(ball))
                    this.Exit();
                else
                    ball.goesLeft = true;
            }
            else if (ball.Y - ball.texture.Height <= upFrame.Y)
            {
                upFrame.hitBall(ball, true);
                ball.goesDown = true;
            }

            else if (ball.Y + ball.texture.Height / 2 >= downFrame.Y)
            {
                downFrame.hitBall(ball, true);
                ball.goesDown = false;
            }
        }
    }
}

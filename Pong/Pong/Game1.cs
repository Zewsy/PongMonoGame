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
        private Ball ball;
        private const int MOVEMENT = 2;

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
            spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}

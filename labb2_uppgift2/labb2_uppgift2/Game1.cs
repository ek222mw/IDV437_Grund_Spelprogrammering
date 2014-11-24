using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace labb2_uppgift2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
            //BallView m_ballView;
            //Ball m_ball = new Ball();
            //BallSimulation m_ballSimulation = new BallSimulation();
            //Texture2D pixel;
            //private int framesize = 20;
           
            SmokeSystem m_smokesystem;
            Texture2D m_smokeTexture2D;
            private float timeElapsed;

            public Game1()
                : base()
            {
                graphics = new GraphicsDeviceManager(this);

               graphics.PreferredBackBufferHeight = 400;
               graphics.PreferredBackBufferWidth = 400;

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
                m_smokesystem = new SmokeSystem(GraphicsDevice.Viewport);
                base.Initialize();
            }

            /// <summary>
            /// LoadContent will be called once per game and is the place to load
            /// all of your content.
            /// </summary>
            protected override void LoadContent()
            {
                // Create a new SpriteBatch, which can be used to draw textures.
                

                // Somewhere in your LoadContent() method:
               // pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
               // pixel.SetData(new[] { Color.White}); // so that we can draw whatever color we want on top of it
                
                
                //m_ballView = new BallView(GraphicsDevice, Content);
                spriteBatch = new SpriteBatch(GraphicsDevice);

                m_smokeTexture2D = Content.Load<Texture2D>("particlesmoke");
                // TODO: use this.Content to load your game content here
            }

            /// <summary>
            /// UnloadContent will be called once per game and is the place to unload
            /// all content.
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
                
                
                if (/*GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || */Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                
                // TODO: Add your update logic here
                //m_ballSimulation.Update(gameTime, m_ball);
                m_smokesystem.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                base.Update(gameTime);
                
                
            }

            /// <summary>
            /// This is called when the game should draw itself.
            /// </summary>
            /// <param name="gameTime">Provides a snapshot of timing values.</param>
            protected override void Draw(GameTime gameTime)
            {
                
                GraphicsDevice.Clear(Color.AliceBlue);

                //Rectangle titleSafeRectangle = GraphicsDevice.Viewport.TitleSafeArea;
                //Vector2 dest = new Vector2(0.5f,0.5f);
                //Uppgift 1
               //m_ballView.drawPostion();
                //Uppgift 2
                //m_ballView.drawreverse();
                //Uppgift3
                //m_ballView.drawscaled();
                //Resten Uppgift 4 labb1
               

               //m_ballView.drawLevel(titleSafeRectangle, framesize, Color.Red, pixel);
               
               //m_ballView.drawball(m_ball, framesize);

                m_smokesystem.Draw(spriteBatch, m_smokeTexture2D);
               

                base.Draw(gameTime);
            }

    }
}

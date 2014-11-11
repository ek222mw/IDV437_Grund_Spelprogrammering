using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game1
{
    
        public class MasterController : Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
            BallView m_ballView;
            Ball m_ball = new Ball();
            BallSimulation m_ballSimulation = new BallSimulation();
            Texture2D pixel;
            private int framesize = 20;

            public MasterController()
                : base()
            {
                graphics = new GraphicsDeviceManager(this);

               graphics.PreferredBackBufferHeight = 600;
               graphics.PreferredBackBufferWidth = 700;

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
                

                // Somewhere in your LoadContent() method:
                pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
                pixel.SetData(new[] { Color.White}); // so that we can draw whatever color we want on top of it

                m_ballView = new BallView(GraphicsDevice, Content);
                spriteBatch = new SpriteBatch(GraphicsDevice);


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
                m_ballSimulation.Update(gameTime, m_ball);
                
                base.Update(gameTime);
                
                
            }

            /// <summary>
            /// This is called when the game should draw itself.
            /// </summary>
            /// <param name="gameTime">Provides a snapshot of timing values.</param>
            protected override void Draw(GameTime gameTime)
            {
                
                GraphicsDevice.Clear(Color.AliceBlue);

                //int borderWidth = GraphicsDevice.Viewport.Width/ 10;
                //int borderHeight = GraphicsDevice.Viewport.Height / 10;

                Rectangle titleSafeRectangle = GraphicsDevice.Viewport.TitleSafeArea;

                //Uppgift 1
                //m_ballView.drawPostion();
                //Uppgift 2
                //m_ballView.drawreverse();
                //Uppgift3
                //m_ballView.drawscaled();
                //Resten Uppgift 4 labb1
                m_ballView.drawLevel(titleSafeRectangle, framesize, Color.Red, pixel);
               
                m_ballView.drawball(m_ball, framesize);
                
                

                base.Draw(gameTime);
            }
        }
    }


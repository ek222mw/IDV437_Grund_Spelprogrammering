using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Projekt
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ShipView m_shipView;
        LevelView m_levelView;
        AsteroidView m_asteroidView;
        
        AsteroidSimulation m_asteroidSimulation;
        Random random = new Random();
        List<Asteroid> AsteroidList = new List<Asteroid>();
        private int m_windowWidth;
        private int m_windowHeight;

        

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 500;
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
            m_windowWidth = GraphicsDevice.Viewport.Width;
            m_windowHeight = GraphicsDevice.Viewport.Height;
            m_asteroidSimulation = new AsteroidSimulation(m_windowWidth,m_windowHeight);
            m_shipView = new ShipView(m_windowWidth,m_windowHeight);
            m_levelView = new LevelView(m_windowWidth, m_windowHeight);
            m_asteroidView = new AsteroidView();
            
            
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

            m_levelView.LoadContent(Content);
            m_shipView.LoadContent(Content);
           
           
            
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
            if (/*GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||*/ Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (Asteroid a in AsteroidList)
            {
                a.Update(gameTime);
            }
             m_asteroidSimulation.CreateAsteroids(Content.Load<Texture2D>("asteroid"), AsteroidList); 

            m_levelView.Update(gameTime);

            m_shipView.Update(gameTime);
            //m_asteroidView.Update(gameTime);

            
           
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {


            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            m_levelView.Draw(spriteBatch);
            m_shipView.Draw(spriteBatch);
            //m_asteroidView.Draw(spriteBatch);
            foreach (Asteroid a in AsteroidList)
            {
                m_asteroidView.Draw(spriteBatch,a.isVisible,a.getPosition,a.getRotation,a.getRotationAngle,a.getTexture);
            }
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

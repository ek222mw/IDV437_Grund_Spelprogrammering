using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projekt.Controller;
using Projekt.Model;
using Projekt.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projekt.Controller
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ShipController m_shipController;
        LevelController m_levelController;
        AsteroidView m_asteroidView;
        Ship m_ship = new Ship();
        AsteroidSimulation m_asteroidSimulation;
        BulletSimulation m_bulletSimulation;
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
            m_shipController = new ShipController(m_windowWidth,m_windowHeight);
            m_levelController = new LevelController(m_windowWidth, m_windowHeight);
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

            m_levelController.LoadContent(Content);
            m_shipController.LoadContent(Content);
           
            
           
           
            
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
                if (a.m_bounceRect.Intersects(m_shipController.m_boundingBox))
                {
                    m_shipController.health = m_ship.LoseLife();
                    a.isVisible = false;
                }

                for (int i = 0; i< m_shipController.m_BulletsList.Count; i++)
                {
                    if (a.m_bounceRect.Intersects(m_shipController.m_BulletsList[i].bulletHitBox))
                    {
                        a.isVisible = false;
                        m_shipController.m_BulletsList.ElementAt(i).isVisible = false;
                    }
                }

                    a.Update(gameTime);
            }
             m_asteroidSimulation.CreateAsteroids(Content.Load<Texture2D>("asteroid"), AsteroidList); 

            m_levelController.Update(gameTime);

            m_shipController.Update(gameTime);
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
            m_levelController.Draw(spriteBatch);
            m_shipController.Draw(spriteBatch);
            //m_asteroidView.Draw(spriteBatch);
            foreach (Asteroid a in AsteroidList)
            {
                m_asteroidView.Draw(spriteBatch,a.isVisible,a.getPosition,/*a.getRotation,a.getRotationAngle,*/a.getTexture);
            }
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

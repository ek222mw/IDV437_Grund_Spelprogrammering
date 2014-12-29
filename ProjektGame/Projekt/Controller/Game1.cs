﻿using Microsoft.Xna.Framework;
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
        List<Asteroid> m_asteroidList = new List<Asteroid>();
        List<Enemy> m_enemyList = new List<Enemy>();
        List<Explosion> m_explosionList = new List<Explosion>();
        ExplosionController m_explosionController;
        EnemyController m_enemyController;
        HUDController m_hudController;
        EnemySimulation m_enemySimulation;          
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
            m_enemySimulation = new EnemySimulation(m_windowWidth, m_windowHeight);
            m_shipController = new ShipController(m_windowWidth,m_windowHeight);
            m_levelController = new LevelController(m_windowWidth, m_windowHeight);
            m_enemyController = new EnemyController(m_windowWidth, m_windowHeight);
            m_hudController = new HUDController(m_windowWidth, m_windowHeight);
            m_explosionController = new ExplosionController(m_windowWidth, m_windowHeight);

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
            m_enemyController.LoadContent(Content);
            m_hudController.LoadContent(Content);

           
            
           
           
            
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
            foreach (Enemy e in m_enemyList)
            {
                if (e.m_boundBox.Intersects(m_shipController.m_boundingBox))
                {
                    m_shipController.health = m_ship.LoseLifeCollideEnemy();
                    e.m_isVisible = false;
                }

                for (int i = 0; i < m_enemyController.m_bulletList.Count; i++)
                {
                    if (m_shipController.m_boundingBox.Intersects(m_enemyController.m_bulletList[i].bulletHitBox))
                    {
                        m_shipController.health = m_ship.LoseLifeEnemyBullets();
                        m_enemyController.m_bulletList.ElementAt(i).isVisible = false;
                    }

                }

                for (int i = 0; i < m_shipController.m_BulletsList.Count; i++)
                {
                    if (m_shipController.m_BulletsList[i].bulletHitBox.Intersects(e.m_boundBox))
                    {
                        m_explosionList.Add(new Explosion(Content.Load<Texture2D>("explosion3"), new Vector2(e.getEnemyPos.X, e.getEnemyPos.Y)));
                        m_hudController.m_playerScore += 20;
                        e.m_isVisible = false;
                        m_shipController.m_BulletsList[i].isVisible = false;
                        

                    }
                }

                e.Update(gameTime);
            }


            foreach (Asteroid a in m_asteroidList)
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
                        m_explosionList.Add(new Explosion(Content.Load<Texture2D>("explosion3"), new Vector2(a.getPosition.X, a.getPosition.Y)));
                        m_hudController.m_playerScore += 5;
                        a.isVisible = false;
                        m_shipController.m_BulletsList.ElementAt(i).isVisible = false;
                    }
                }

                    a.Update(gameTime);
            }

            m_asteroidSimulation.CreateAsteroids(Content.Load<Texture2D>("asteroid"), m_asteroidList);
            m_enemySimulation.CreateEnemies(Content.Load<Texture2D>("enemyship"), m_enemyList);
            m_hudController.Update(gameTime);
            m_levelController.Update(gameTime);

            m_shipController.Update(gameTime);
            m_enemyController.Update(gameTime, m_enemyList);
            foreach (Explosion ex in m_explosionList)
            {
                ex.Update(gameTime);
            }

            m_explosionController.Update(gameTime, m_explosionList);
           

            
           
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
            m_hudController.Draw(spriteBatch);
            foreach (Asteroid a in m_asteroidList)
            {
                m_asteroidView.Draw(spriteBatch,a.isVisible,a.getPosition,/*a.getRotation,a.getRotationAngle,*/a.getTexture);
            }
            m_enemyController.Draw(spriteBatch, m_enemyList);
            m_explosionController.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Projekt.Model;
using Projekt.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projekt.Model
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {

        public enum State
        {
            Menu,
            Playing,
            Gameover,
            Pause
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ShipController m_shipController;
        LevelController m_levelController;
        AsteroidView m_asteroidView;
        Ship m_ship = new Ship();
        AsteroidSimulation m_asteroidSimulation;
        Random random = new Random();
        List<Asteroid> m_asteroidList = new List<Asteroid>();
        List<Enemy> m_enemyList = new List<Enemy>();
        List<Explosion> m_explosionList = new List<Explosion>();
        ExplosionController m_explosionController;
        EnemyController m_enemyController;
        HUDController m_hudController;
        EnemySimulation m_enemySimulation;
        MenuView m_menuView = new MenuView();
        LevelView m_levelView = new LevelView();
        private int m_windowWidth;
        private int m_windowHeight;
        Sound m_sound = new Sound();
        Texture2D m_menuTexture, m_gameoverTexture, m_pauseTexture;
        Texture2D m_level2Texture, m_level3Texture;
        private float m_level2; 
        State gameState = State.Menu;
        private int numberOfEnemies = 3;
        private float m_level3;
        Vector2 m_newlevelPos;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 600;
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
            m_sound.LoadContent(Content);
            m_menuTexture = Content.Load<Texture2D>("menu");
            m_gameoverTexture = Content.Load<Texture2D>("gameover");
            m_pauseTexture = Content.Load<Texture2D>("pause");
            m_level2Texture = Content.Load<Texture2D>("Level2");
            m_level3Texture = Content.Load<Texture2D>("Level3");

           

           
            
           
           
            
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

            switch (gameState)
            {
                case State.Playing:
                    {
                        KeyboardState keystate = Keyboard.GetState();
                        m_level2 += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        m_level3 += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (keystate.IsKeyDown(Keys.P))
                        {
                            gameState = State.Pause;
                        }
                        // TODO: Add your update logic here
                        if (m_level2 >= 30)
                        {
                            if (m_level3 >= 60)
                            {
                                numberOfEnemies = 5;
                            }
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
                                        m_sound.m_explosion.Play();
                                        m_explosionList.Add(new Explosion(Content.Load<Texture2D>("explosion3"), new Vector2(e.getEnemyPos.X, e.getEnemyPos.Y)));
                                        m_hudController.m_playerScore += 20;
                                        e.m_isVisible = false;
                                        m_shipController.m_BulletsList[i].isVisible = false;


                                    }
                                }

                                e.Update(gameTime);
                            }
                            m_enemySimulation.CreateEnemies(Content.Load<Texture2D>("enemyship"), m_enemyList, numberOfEnemies);
                            m_enemyController.Update(gameTime, m_enemyList);
                        }


                        foreach (Asteroid a in m_asteroidList)
                        {
                            if (a.m_bounceRect.Intersects(m_shipController.m_boundingBox))
                            {
                                m_shipController.health = m_ship.LoseLife();
                                a.isVisible = false;
                            }

                            for (int i = 0; i < m_shipController.m_BulletsList.Count; i++)
                            {
                                if (a.m_bounceRect.Intersects(m_shipController.m_BulletsList[i].bulletHitBox))
                                {
                                    m_sound.m_explosion.Play();
                                    m_explosionList.Add(new Explosion(Content.Load<Texture2D>("explosion3"), new Vector2(a.getPosition.X, a.getPosition.Y)));
                                    m_hudController.m_playerScore += 5;
                                    a.isVisible = false;
                                    m_shipController.m_BulletsList.ElementAt(i).isVisible = false;
                                }
                            }

                            a.Update(gameTime);
                        }

                        m_asteroidSimulation.CreateAsteroids(Content.Load<Texture2D>("asteroid"), m_asteroidList);
                        
                        m_hudController.Update(gameTime);
                        m_levelController.Update(gameTime);

                        m_shipController.Update(gameTime);
                       
                        foreach (Explosion ex in m_explosionList)
                        {
                            ex.Update(gameTime);
                        }

                        m_explosionController.Update(gameTime, m_explosionList);
                        if (m_ship.getLife <= 0)
                        {
                            gameState = State.Gameover;
                        }
                        break;
           

                    }

                case State.Menu:
                        {
                            KeyboardState keystate = Keyboard.GetState();

                            if (keystate.IsKeyDown(Keys.Enter))
                            {
                                m_shipController.m_position = new Vector2(m_shipController.vx, m_shipController.vy);
                                m_shipController.health = m_ship.newGame();
                                m_hudController.m_playerScore = 0;
                                m_enemyList.Clear();
                                m_asteroidList.Clear();
                                m_level2 = 0;
                                m_level3 = 0;
                                numberOfEnemies = 3;

                                gameState = State.Playing;
                                m_sound.m_backgroundMusic.Play();
                            }

                            break;
                        }
                case State.Gameover:
                        {
                            KeyboardState keystate = Keyboard.GetState();

                            if (keystate.IsKeyDown(Keys.M))
                            {
                                gameState = State.Menu;
                            }
                            else if (keystate.IsKeyDown(Keys.N))
                            {
                                m_shipController.m_position = new Vector2(m_shipController.vx, m_shipController.vy);
                                m_shipController.health = m_ship.newGame();
                                m_hudController.m_playerScore = 0;
                                m_enemyList.Clear();
                                m_asteroidList.Clear();
                                m_level2 = 0;
                                m_level3 = 0;
                                numberOfEnemies = 3;

                                gameState = State.Playing;
                            }
                            else if (keystate.IsKeyDown(Keys.Q))
                            {
                                Exit();
                            }

                            MediaPlayer.Stop();
                            break;
                        }
                case State.Pause:
                        {
                            KeyboardState keystate = Keyboard.GetState();

                            if (keystate.IsKeyDown(Keys.Enter))
                            {
                                gameState = State.Playing;
                            }
                            else if (keystate.IsKeyDown(Keys.M))
                            {
                                gameState = State.Menu;
                            }
                            else if (keystate.IsKeyDown(Keys.Q))
                            {
                                Exit();
                            }

                            break;

                        }

            }

           

            
           
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

            switch (gameState)
            {

                case State.Playing:
                    {
                        m_newlevelPos = new Vector2(m_windowWidth / 4.5f, 50);
                        m_levelController.Draw(spriteBatch);
                       
                        if (m_level2 >= 30)
                        {
                           
                            if (m_level2 <= 32)
                            {
                                
                                m_levelView.DrawNewLevel(spriteBatch, m_newlevelPos, m_level2Texture);
                            }
                            else if (m_level3 >= 60 && m_level3 <= 62)
                            {
                                m_levelView.DrawNewLevel(spriteBatch, m_newlevelPos, m_level3Texture);
                            }

                            m_enemyController.Draw(spriteBatch, m_enemyList);
                        }
                        foreach (Asteroid a in m_asteroidList)
                        {
                            m_asteroidView.Draw(spriteBatch, a.isVisible, a.getPosition,/*a.getRotation,a.getRotationAngle,*/a.getTexture);
                        }
                        m_shipController.Draw(spriteBatch);
                        m_hudController.Draw(spriteBatch);
                        m_explosionController.Draw(spriteBatch);
                       

                        break;
                    }

                case State.Menu:
                    {
                        m_menuView.Draw(spriteBatch, m_menuTexture);
                        break;
                    }

                case State.Gameover:
                    {
                        m_menuView.Draw(spriteBatch, m_gameoverTexture);
                        break;
                    }
                case State.Pause:
                    {
                        m_menuView.Draw(spriteBatch, m_pauseTexture);
                        break;
                    }



            }

           
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

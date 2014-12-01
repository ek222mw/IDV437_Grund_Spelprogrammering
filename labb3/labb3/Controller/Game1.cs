using labb3.Model;
using labb3.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace labb3
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SplitterSystem m_splittersystem;
        Texture2D m_splitterTexture2D;
        private float timeElapsed;
        BallView m_ballView;
        Ball m_ball = new Ball();
        BallSimulation m_ballSimulation = new BallSimulation();
        Texture2D pixel;
        private int framesize = 20;
        SmokeSystem m_smokesystem;
        Texture2D m_smokeTexture2D;
        Texture2D m_texture2d;
        Rectangle destRect;
        ExplotionSystem m_explotionSystem;
        NewEffectSystem m_newEffectSystem;
        Texture2D m_newTexture2D;
        private List<SmokeSystem> effects;
        private MouseState currentMouseState;
        private MouseState previousMouseState;
        private Vector2 mousePos;
        private List<SplitterSystem> splitterEffects;
        private Vector2 mousePosSplitter;

        public Game1()
            : base()
        {
            this.IsMouseVisible = true;
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
            MouseState mouse = Mouse.GetState();
            m_splittersystem = new SplitterSystem(GraphicsDevice.Viewport);
            m_smokesystem = new SmokeSystem(GraphicsDevice.Viewport, mousePos);
            destRect = new Rectangle(0, 0, 128, 128);
            
            m_newEffectSystem = new NewEffectSystem(GraphicsDevice.Viewport);
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
            m_splitterTexture2D = Content.Load<Texture2D>("spark");
            m_smokeTexture2D = Content.Load<Texture2D>("particlesmoke");
            effects = new List<SmokeSystem>();
            splitterEffects = new List<SplitterSystem>();
            pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White }); // so that we can draw whatever color we want on top of it
            m_newTexture2D = Content.Load<Texture2D>("spark");
            m_ballView = new BallView(GraphicsDevice, Content);
            m_texture2d = Content.Load<Texture2D>("explosion");
            m_explotionSystem = new ExplotionSystem(GraphicsDevice.Viewport, Content);
           
            
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
            
            //m_ballSimulation.Update(gameTime, m_ball);
            //m_explotionSystem.Draw(spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
            
            MouseState CurrentMouseClicked = Mouse.GetState();
            MouseState previousmouseClicked = Mouse.GetState();

            m_newEffectSystem.setbuttonPressed(CurrentMouseClicked);
            m_splittersystem.setbuttonPressed(CurrentMouseClicked);


            if (m_splittersystem.getButtonStatus())
            {
                m_splittersystem.Update((float)gameTime.ElapsedGameTime.TotalSeconds, CurrentMouseClicked);
            }

            if (m_newEffectSystem.getButtonStatus())
            {
                
                m_newEffectSystem.Update((float)gameTime.ElapsedGameTime.TotalSeconds, CurrentMouseClicked);

            }
            bool mouseIsClicked = false;
            currentMouseState = Mouse.GetState();

            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                mouseIsClicked = true;
            }

            previousMouseState = currentMouseState;

            
            if (mouseIsClicked)
            {
                mousePos = m_smokesystem.GetMousePos();
                //mousePosSplitter = m_splittersystem.GetMousePos();


                effects.Add(new SmokeSystem(GraphicsDevice.Viewport,mousePos));
                //splitterEffects.Add(new SplitterSystem(GraphicsDevice.Viewport, mousePosSplitter));
                
            }

            //foreach (var splitterparticle in splitterEffects)
            //{
            //    splitterparticle.Update((float)gameTime.ElapsedGameTime.TotalSeconds, CurrentMouseClicked);
            //}

            foreach (var particle in effects)
            {
                particle.Update((float)gameTime.ElapsedGameTime.TotalSeconds,CurrentMouseClicked);
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
            Rectangle titleSafeRectangle = GraphicsDevice.Viewport.TitleSafeArea;
            // TODO: Add your drawing code here
            //m_ballView.drawLevel(titleSafeRectangle, framesize, Color.Red, pixel);

            //m_ballView.drawball(m_ball, framesize);
            
            
            //m_explotionSystem.Draw(spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
            MouseState mouse = Mouse.GetState();
            m_newEffectSystem.setbuttonPressed(mouse);
            m_splittersystem.setbuttonPressed(mouse);

            if (m_splittersystem.getButtonStatus())
            {
                m_splittersystem.Draw(spriteBatch, m_splitterTexture2D);
            }

            if (m_newEffectSystem.getButtonStatus())
            {
                
                m_newEffectSystem.Draw(spriteBatch, m_newTexture2D);
            }
            foreach(var smoke in effects)
            {
                smoke.Draw(spriteBatch, m_smokeTexture2D);
            }
            
            base.Draw(gameTime);
        }
    }
}

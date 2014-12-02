using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace labb3.View
{
    class SmokeSystem
    {
        

        private List<SmokeParticle> particles = new List<SmokeParticle>();

        
        private float m_totaltime = 0;
        private float m_delay = 0.2f;
        private bool setSmoke;
        private Camera m_camera;
        private MouseState currentMouseState;
        private Vector2 m_position;
        public SmokeSystem(Viewport viewport, Vector2 a_position)
        {
            m_camera = new Camera(viewport.Width, viewport.Height);
            m_position = a_position;
        }

        public void Update(float a_timeElapsed, MouseState a_ms)
        {
            m_totaltime += a_timeElapsed;
           
                if (m_totaltime >= m_delay)
                {
                    m_totaltime = 0;

                    particles.Add(new SmokeParticle(m_position));
                }
            
           
                for (int i = 0; i < particles.Count; i++)
                {
                    
                        particles[i].Update(a_timeElapsed);

                       
                            if (particles[i].ParticleHasDead())
                            {
                                particles[i].doRespawn();
                            }
                        
                }
            

        }


        public void Draw(SpriteBatch a_spriteBatch, Texture2D a_textureSplitter)
        {


            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Draw(a_spriteBatch, a_textureSplitter, m_camera);
            }



        }

        public bool getButtonStatus()
        {
            return setSmoke;
        }


        internal void setButtonStatus(MouseState a_ms)
        {
              a_ms = Mouse.GetState();
              if (a_ms.LeftButton == ButtonState.Pressed)
              {
                  setSmoke = true;
              }
        }

        public Vector2 GetMousePos()
        {
            currentMouseState = Mouse.GetState();

            float x = currentMouseState.X;
            float y = currentMouseState.Y;

            Vector2 mouseModelPos = m_camera.getModelCoordinates(x, y);

            return mouseModelPos;
        }

       
    }
}

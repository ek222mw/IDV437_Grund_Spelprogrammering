using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb2_uppgift4
{
    class SmokeSystem
    {



        Texture2D m_texture;

        private List<SmokeParticle> particles = new List<SmokeParticle>();
        
        private float m_time = 0;
        private float m_runningtime = 3;
        private float m_MaxSpeed = 0.3f;
        private float m_totaltime = 0;
        private float m_delay = 0.2f;
        

        private Camera m_camera;

        public SmokeSystem(Viewport viewport)
        {
           
            m_camera = new Camera(viewport.Width, viewport.Height);
        }




        //internal void LoadContent(ContentManager a_content)
        //{
        //    m_texture = a_content.Load<Texture2D>("ball");
        //}

        public void Update(float a_timeElapsed)
        {
            m_totaltime += a_timeElapsed;

            if (m_totaltime >= m_delay)
            {
                m_totaltime = 0;

                particles.Add(new SmokeParticle());
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


    }
}

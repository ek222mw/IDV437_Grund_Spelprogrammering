using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Controller_Labb2;

namespace Controller_Labb2
{

    class SplitterSystem
    {
        private const int MAX_PARTICLES = 100;

        Texture2D m_texture;

        SplitterParticle[] m_particles;

        private float m_time=0;
        private float m_runningtime = 3;
        private float m_MaxSpeed = 0.3f;

        private Camera m_camera;

        public SplitterSystem(Viewport viewport)
        {
            m_camera = new Camera(viewport.Width, viewport.Height);

            m_particles = new SplitterParticle[MAX_PARTICLES];
            

           

            DoNewSystem();

        }

        private void DoNewSystem()
        {
            Random random = new Random();

            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                Vector2 m_direct = new Vector2(((float)random.NextDouble() - 0.5f), ((float)random.NextDouble() - 0.5f));
                m_direct.Normalize();
                m_direct = m_direct * ((float)random.NextDouble() * m_MaxSpeed);
                m_particles[i] = new SplitterParticle(m_direct);
            }


        }


        //internal void LoadContent(ContentManager a_content)
        //{
        //    m_texture = a_content.Load<Texture2D>("ball");
        //}

        public void Update(float a_timeElapsed)
        {
            m_time += a_timeElapsed;

             for (int i = 0; i < MAX_PARTICLES; i++)
             {
                m_particles[i].Update(a_timeElapsed);
             }

             if (m_time > m_runningtime)
             {
                 m_time = 0;
                 DoNewSystem();

             }

        }


        public void Draw(SpriteBatch a_spriteBatch, Texture2D a_textureSplitter)
        {


            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                m_particles[i].Draw(a_spriteBatch, a_textureSplitter, m_camera);
            }
                
                
            
        }

    }
}

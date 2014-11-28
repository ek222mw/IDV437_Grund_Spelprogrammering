using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb2_uppgift4
{
    class NewEffectSystem
    {

        private const int MAX_PARTICLES = 1000;

        //Texture2D m_texture;

        NewParticle[] m_particles;

        private float m_time=0;
        private float m_MaxRunningtime =3;
        private float m_MinRunningtime = 1;
        private float m_MaxSpeed = 0.3f;
        private float m_minSpeed = 0.25f;
        private bool hasASystem = false;
        private Camera m_camera;

        public NewEffectSystem(Viewport viewport)
        {
            m_camera = new Camera(viewport.Width, viewport.Height);

            m_particles = new NewParticle[MAX_PARTICLES];
            

           

           

        }

        private void DoNewSystem()
        {
            Random random = new Random();

            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                Vector2 m_direct = new Vector2(((float)random.NextDouble()-0.5f), ((float)random.NextDouble()-0.5f));
                m_direct.Normalize();
                float dist = ((float)random.NextDouble());
                m_direct = m_direct * (dist * (m_MaxSpeed- m_minSpeed)+ m_minSpeed);

                float randColor = dist;
                Color color = new Color(1, randColor,randColor);
                m_particles[i] = new NewParticle(m_direct,color);
            }
            hasASystem = true;


        }


        //internal void LoadContent(ContentManager a_content)
        //{
        //    m_texture = a_content.Load<Texture2D>("ball");
        //}

        public void Update(float a_timeElapsed)
        {
            m_time += a_timeElapsed;
            if (hasASystem)
            {
                for (int i = 0; i < MAX_PARTICLES; i++)
                {
                    m_particles[i].Update(a_timeElapsed);
                }

            }
            if (m_time > m_MinRunningtime && hasASystem == false)
            {
                
                DoNewSystem();

            }
            else if(hasASystem && m_time > m_MaxRunningtime)
            {
                m_time = 0;
                hasASystem = false;
            }
            

        }


        public void Draw(SpriteBatch a_spriteBatch, Texture2D a_textureSplitter)
        {

            if (hasASystem)
            {
                for (int i = 0; i < MAX_PARTICLES; i++)
                {
                    m_particles[i].Draw(a_spriteBatch, a_textureSplitter, m_camera);
                }
            }
                
                
            
        }



    }
}

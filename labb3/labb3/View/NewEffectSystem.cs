using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace labb3.View
{
    class NewEffectSystem
    {

        private const int MAX_PARTICLES = 1000;

        //Texture2D m_texture;

        NewParticle[] m_particles;

        private float m_time = 0;
        private float m_MaxRunningtime = 3;
        private float m_MinRunningtime = 1;
        private float m_MaxSpeed = 0.3f;
        private float m_minSpeed = 0.25f;
        private bool hasASystem = false;
        private Camera m_camera;
        private MouseState m_ms;
        private bool buttonIsPressed;

        public NewEffectSystem(Viewport viewport)
        {
            m_camera = new Camera(viewport.Width, viewport.Height);

            m_particles = new NewParticle[MAX_PARTICLES];

        }

        private void DoNewSystem(MouseState a_ms)
        {
            Random random = new Random();

            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                Vector2 m_direct = new Vector2(((float)random.NextDouble() - 0.5f), ((float)random.NextDouble() - 0.5f));
                m_direct.Normalize();
                float dist = ((float)random.NextDouble());
                m_direct = m_direct * (dist * (m_MaxSpeed - m_minSpeed) + m_minSpeed);

                float randColor = dist;
                Color color = new Color(1, randColor, randColor);
                m_particles[i] = new NewParticle(m_direct, color,m_camera,a_ms);
            }
            hasASystem = true;


        }


        public void Update(float a_timeElapsed,MouseState a_ms)
        {
            m_ms = a_ms;
            m_time += a_timeElapsed;
            if (hasASystem)
            {
                for (int i = 0; i < MAX_PARTICLES; i++)
                {
                    m_particles[i].Update(a_timeElapsed);
                }

            }
            if (m_time > m_MinRunningtime && hasASystem == false && buttonIsPressed)
            {
                
                DoNewSystem(m_ms);

            }
            else if (hasASystem && m_time > m_MaxRunningtime)
            {
                buttonIsPressed = false;
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

        public void setbuttonPressed(MouseState ms)
        {
            ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed)
            {
                buttonIsPressed = true;
            }
        }

        public bool getButtonStatus()
        {
            return buttonIsPressed;
        }

    }
}

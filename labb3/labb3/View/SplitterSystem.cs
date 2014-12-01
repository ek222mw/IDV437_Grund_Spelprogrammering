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
    class SplitterSystem
    {

        private const int MAX_PARTICLES = 100;

        

        SplitterParticle[] m_particles;
        private bool hasASystem = false;
        private float m_time = 0;
        private float m_runningtime = 1;
        private float m_MaxSpeed = 0.3f;
        private bool buttonIsPressed;
        private Camera m_camera;
        private MouseState m_ms;
        Vector2 m_position;
        private MouseState currentMouseState;
        public SplitterSystem(Viewport viewport)
        {
            m_camera = new Camera(viewport.Width, viewport.Height);

            m_particles = new SplitterParticle[MAX_PARTICLES];

           

            
          // DoNewSystem(m_ms);

        }

        private void DoNewSystem(MouseState a_ms)
        {
            Random random = new Random();

            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                Vector2 m_direct = new Vector2(((float)random.NextDouble() - 0.5f), ((float)random.NextDouble() - 0.5f));
                m_direct.Normalize();
                m_direct = m_direct * ((float)random.NextDouble() * m_MaxSpeed);
                m_particles[i] = new SplitterParticle(m_direct,m_camera,a_ms);
            }
            hasASystem = true;


        }


        public void Update(float a_timeElapsed, MouseState a_ms)
        {
            m_time += a_timeElapsed;
            m_ms = a_ms;
            if (hasASystem)
            {
                for (int i = 0; i < MAX_PARTICLES; i++)
                {
                    m_particles[i].Update(a_timeElapsed);
                }
            }

           

            if (m_time > m_runningtime)
            {
                hasASystem = false;
                buttonIsPressed = false;
                m_time = 0;
                DoNewSystem(a_ms);

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

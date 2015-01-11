using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.Model
{
    class Asteroid
    {
        private float m_y = -0.1f;
        private float m_x = 0.5f;
        public bool isVisible;
        Random random = new Random();
        Rectangle m_bounceRect;
        private Vector2 m_position;
        private Texture2D m_texture;
        private int m_windowWidth;
        private int m_windowHeight;
        private int m_speed;
       
        




        public Asteroid(int a_width, int a_height, Texture2D a_Texture, Vector2 a_newpos)
        {
            m_position = a_newpos;
            m_texture = a_Texture;
            m_windowWidth = a_width;
            m_windowHeight = a_height;
            m_speed = 5;
            isVisible = true;
        }

        public Asteroid()
        {
        }


        public void Update(GameTime timeElapsed)
        {

            m_bounceRect = new Rectangle((int)m_position.X, (int)m_position.Y, m_texture.Width, m_texture.Height);

            m_position.Y = m_position.Y + m_speed;

            if (m_position.Y >= m_windowHeight)
            {
                m_position.Y = 0;

                Random random = new Random();
                float randomposX = random.Next(20, m_windowWidth-30);

                m_position.X = randomposX;
            }

        }


        public Vector2 getPosition
        {
            get
            {
                return m_position;
            }
        }

        public Texture2D getTexture
        {
            get
            {
                return m_texture;
            }
        }

        public float getPosX
        {
            get
            {
                return m_x;
            }
        }

        public float getPosY
        {
            get
            {
                return m_y;
            }
        }

        public float getSpeed
        {
            get
            {
                return m_speed;
            }
        }

        public Rectangle getBounceRec
        {
            get
            {
                return m_bounceRect;
            }
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt
{
    class Asteroid
    {
        private float m_y = -0.1f;
        private float m_x = 0.5f;
        //private float m_speed = 0.02f;
        public bool isVisible;
        

        Random random = new Random();
        public float m_rotationAngle;
        public Rectangle m_bounceRect;
        private Vector2 m_position;
        private Texture2D m_texture;
        private int m_windowWidth;
        private int m_windowHeight;
        private int m_speed;
        public Vector2 m_rotation;
        




        public Asteroid(int a_width, int a_height, Texture2D a_Texture, Vector2 a_newpos)
        {
            m_position = a_newpos;
            m_texture = a_Texture;
            m_windowWidth = a_width;
            m_windowHeight = a_height;
            m_speed = 5;
            isVisible = true;
            m_rotation.X = m_texture.Width / 2;
            m_rotation.Y = m_texture.Height / 2;
            


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
                float randomposX = random.Next(1, m_windowWidth);

                m_position.X = randomposX;
            }

            float ElapsedTime = (float)timeElapsed.ElapsedGameTime.TotalSeconds;
            m_rotationAngle += ElapsedTime;
            float m_Circle = MathHelper.Pi * 2;
            m_rotationAngle = m_rotationAngle % m_Circle;
        }


        public Vector2 getPosition
        {
            get
            {
                return m_position;
            }
        }

        public Vector2 getRotation
        {
            get
            {
                return m_rotation;
            }
        }

        public float getRotationAngle
        {
            get
            {
                return m_rotationAngle;
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
    }
}

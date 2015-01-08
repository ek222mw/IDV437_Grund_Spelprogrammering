using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.Model
{
    class Enemy2
    {

        public Rectangle m_boundBox;
        Texture2D m_texture;
        Vector2 m_position;
        public int m_speed;
        public bool m_isVisible;
        List<Bullet> m_bulletList;
        private int m_windowWidth;
        private int m_windowHeight;
        private int health;
        

        public Enemy2(int a_width, int a_height, Texture2D a_newTexture, Vector2 a_newPos)
        {
            m_texture = a_newTexture;
            m_bulletList = new List<Bullet>();
            m_position = a_newPos;
            m_speed = 6;
            m_isVisible = true;
            m_windowWidth = a_width;
            m_windowHeight = a_height;
            health = 40;
        }

        public Enemy2()
        {
        }

        public void Update(GameTime timeElapsed)
        {

            m_boundBox = new Rectangle((int)m_position.X, (int)m_position.Y, m_texture.Width, m_texture.Height);

            m_position.Y += m_speed;

            if (m_position.Y >= m_windowHeight)
            {
                m_position.Y = 0;

                Random random = new Random();
                float randomposX = random.Next(1, m_windowWidth);

                m_position.X = randomposX;
            }

            
        }

        public Vector2 getEnemyPos
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

        public bool getIsVisible
        {
            get
            {
                return m_isVisible;
            }
        }

        public int getHealth
        {
            get
            {
                return health;
            }
        }

        public int EnemyLoseLife()
        {
            health -= 20;
            return health;
        }
    }



}


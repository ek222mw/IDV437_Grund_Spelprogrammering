using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt
{
    class AsteroidView
    {
        public Texture2D m_texture;
        public Vector2 m_position;
        public Vector2 m_rotation;
        public float m_rotationAngle;
        public bool m_isColliding = false;
        public bool m_Destroyed = false;
        public Rectangle m_bounceRect;
        private int m_windowWidth;
        private int m_windowHeight;
        Camera m_camera;
        Asteroid m_asteroid;

        public AsteroidView(int a_width, int a_height)
        {

            m_windowWidth = a_width;
            m_windowHeight = a_height;
            m_asteroid = new Asteroid();
            m_camera = new Camera(m_windowWidth, m_windowHeight);
            float vx = m_camera.getAsteroidPosX();
            float vy = m_camera.getAsteroidPosY();
            m_position = new Vector2(vx, vy);
        }


        public void LoadContent(ContentManager a_content)
        {
            m_texture = a_content.Load<Texture2D>("asteroid");
            m_rotation.X = m_texture.Width / 2;
            m_rotation.Y = m_texture.Height / 2;

        }

        public void Update(GameTime timeElapsed)
        {

            m_bounceRect = new Rectangle((int)m_position.X, (int)m_position.Y, m_texture.Width, m_texture.Height);

            m_position.Y = m_position.Y + m_camera.getAsteroidSpeed();

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

        public void Draw(SpriteBatch a_spriteBatch)
        {
            if (m_Destroyed == false)
            {
                a_spriteBatch.Draw(m_texture, m_position, null, Color.White, m_rotationAngle, m_rotation, 1.0f, SpriteEffects.None, 0.0f);
            }
            

        }


    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb3.View
{
    class NewParticle
    {

        private Color m_color;
        private Vector2 m_velocity;
        private Vector2 m_position;
        private Vector2 m_particleAcceleration;
        private float m_sizeSplitter = 0.03f;

        public NewParticle(Vector2 a_velocity, Color a_color)
        {
            m_position = new Vector2(0.5f, 0.5f);
            m_velocity = a_velocity;
            m_particleAcceleration = new Vector2(0, 0);
            m_color = a_color;

        }

        public void Update(float elapsedTime)
        {
            Vector2 m_NewVelocity = new Vector2();
            Vector2 m_NewPosition = new Vector2();


            m_NewVelocity.X = m_velocity.X + elapsedTime * m_particleAcceleration.X;
            m_NewVelocity.Y = m_velocity.Y + elapsedTime * m_particleAcceleration.Y;
            m_NewPosition.X = m_position.X + elapsedTime * m_velocity.X;
            m_NewPosition.Y = m_position.Y + elapsedTime * m_velocity.Y;

            m_position = m_NewPosition;

            m_velocity = m_NewVelocity;


        }




        public void Draw(SpriteBatch a_spriteBatch, Texture2D a_textureSplitter, Camera m_camera)
        {

            a_spriteBatch.Begin();
            a_spriteBatch.Draw(a_textureSplitter, m_camera.ScaleParticles(m_position.X, m_position.Y, m_sizeSplitter), m_color);
            a_spriteBatch.End();


        }

    }
}

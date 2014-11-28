using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb2_uppgift4
{
    class SmokeParticle
    {

        private Vector2 m_velocity;
        private Vector2 m_position;
        private Vector2 m_particleAcceleration;

        private float m_timeLived;
        private float m_maxLifeTime;
        private float m_maxTimeToLive = 3.0f;
        private float m_rotation = 0.2f;
        private float m_maxSpeed = 0.3f;
        private bool hasASystem = false;
        private float m_MaxRunningtime = 3;
        private float m_MinRunningtime = 1;

        public SmokeParticle()
        {
            m_position = new Vector2(0.5f, 0.5f);
            m_particleAcceleration = new Vector2(0, -0.3f);
            m_timeLived = 0;
            m_maxLifeTime = 2.0f;
            //doRespawn();

        }



        public void Update(float elapsedTime)
        {
            Vector2 m_NewVelocity = new Vector2();
            Vector2 m_NewPosition = new Vector2();
            m_timeLived += elapsedTime;

            if (hasASystem)
            {
                m_NewVelocity.X = m_velocity.X + elapsedTime * m_particleAcceleration.X;
                m_NewVelocity.Y = m_velocity.Y + elapsedTime * m_particleAcceleration.Y;
                m_NewPosition.X = m_position.X + elapsedTime * m_velocity.X;
                m_NewPosition.Y = m_position.Y + elapsedTime * m_velocity.Y;


                m_position = m_NewPosition;
                m_velocity = m_NewVelocity;
            }
            if (m_timeLived > m_MinRunningtime && hasASystem == false)
            {

                doRespawn();

            }
            else if (hasASystem && m_timeLived > m_MaxRunningtime)
            {
                m_timeLived = 0;
                hasASystem = false;
            }


        }




        public void Draw(SpriteBatch a_spriteBatch, Texture2D a_textureSplitter, Camera m_camera)
        {
            float time = m_timeLived / m_maxLifeTime;
            float startVal = 1.0f;
            float endval = 0.0f;
            m_rotation += 0.02f;
            float Visibility = endval * time + (1.0f - time) * startVal;

            float size = 3.0f + time * 6.0f;

            Color color = new Color(Visibility, Visibility, Visibility, Visibility);

            Vector2 m_orgin = new Vector2(a_textureSplitter.Bounds.Width / 2, a_textureSplitter.Bounds.Height / 2);

            if (hasASystem)
            {
                a_spriteBatch.Begin();
                a_spriteBatch.Draw(a_textureSplitter, m_camera.ScaleParticlesSmoke(m_position.X, m_position.Y), new Rectangle(0, 0, a_textureSplitter.Bounds.Width, a_textureSplitter.Bounds.Height), color, m_rotation, m_orgin, size, SpriteEffects.None, 0);
                a_spriteBatch.End();
            }


        }



        public bool doRespawn()
        {
            m_position = new Vector2(0.5f, 0.5f);

            Random rand = new Random();
            m_velocity = new Vector2(((float)rand.NextDouble() - 0.5f), ((float)rand.NextDouble() - 0.5f));
            m_velocity.Normalize();
            m_velocity = m_velocity * ((float)rand.NextDouble() * m_maxSpeed);
            return hasASystem = true;

        }

        public bool ParticleHasDead()
        {
            return m_timeLived >= m_maxTimeToLive;
        }


    }
}

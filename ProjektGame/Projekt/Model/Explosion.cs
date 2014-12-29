using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.Model
{
    class Explosion
    {
        private Texture2D m_texture;
        private Vector2 m_position;
        private float m_timer;
        private float m_interval;
        public bool m_isVisible;
        private Rectangle m_sourceRect;
        private Vector2 m_origin;
        private int m_frameNow, m_spriteWidth, m_spriteHeight;

        public Explosion(Texture2D a_newTexture, Vector2 a_newPos)
        {
            m_position = a_newPos;
            m_texture = a_newTexture;
            m_timer = 0;
            m_interval = 20f;
            m_frameNow = 1;
            m_spriteHeight = 128;
            m_spriteWidth = 128;
            m_isVisible = true;

        }

        public void Update(GameTime gameTime)
        {
            m_timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (m_timer > m_interval)
            {
                m_frameNow++;
                m_timer = 0;
            }

            if (m_frameNow == 17)
            {
                m_isVisible = false;
                m_frameNow = 0;
            }

            m_sourceRect = new Rectangle(m_frameNow * m_spriteWidth, 0, m_spriteWidth, m_spriteHeight);
            m_origin = new Vector2(m_sourceRect.Width / 2, m_sourceRect.Height / 2);

        }

        public Texture2D getTexture
        {
            get
            {
                return m_texture;
            }
        }

        public Vector2 getPos
        {
            get
            {
                return m_position;
            }
        }

        public bool getVisibilityStatus
        {
            get
            {
                return m_isVisible;
            }
        }

        public Rectangle getSourceRect
        {
            get
            {
                return m_sourceRect;
            }
        }

        public Vector2 getOrigin
        {
            get
            {
                return m_origin;
            }
        }



    }
}

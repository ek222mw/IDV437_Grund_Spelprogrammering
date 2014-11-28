using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb3.View
{
    class ExplotionParticle
    {

        Texture2D m_explosion;
        private Vector2 m_position;
        private float m_timehasPast;
        private float m_maxTime = 1.5f;
        private int m_numberOfFrames = 24;
        private int m_FramesX = 4;
        private int m_FrameSize;
        private float scale = 0.7f;
        Camera m_camera;

        public ExplotionParticle(Viewport viewPort, Vector2 Position, ContentManager content)
        {
            m_explosion = content.Load<Texture2D>("explosion");
            m_camera = new Camera(viewPort.Width, viewPort.Height);
            m_position = Position;
            m_FrameSize = m_explosion.Bounds.Width / m_FramesX;
            scale = scale * m_camera.getScaleExplotion();
        }

        public void Draw(SpriteBatch spriteBatch, float elapsedTime)
        {

            if (m_timehasPast >= m_maxTime + 1.5f)
            {
                m_timehasPast = 0;
            }
            m_timehasPast += elapsedTime;

            Vector2 m_scalePosition = m_camera.scaleVec(m_position.X, m_position.Y);
            float m_percentAnimated = m_timehasPast / m_maxTime;
            int m_frame = (int)(m_percentAnimated * m_numberOfFrames);
            int m_frameX = m_frame % m_FramesX;
            int m_frameY = m_frame / m_FramesX;

            spriteBatch.Begin();
            spriteBatch.Draw(m_explosion, new Rectangle((int)m_scalePosition.X - (int)scale / 2, (int)m_scalePosition.Y - (int)scale / 2, (int)scale, (int)scale), new Rectangle(m_frameX * m_FrameSize, m_frameY * m_FrameSize, m_FrameSize, m_FrameSize), Color.White);
            spriteBatch.End();
        }

    }
}

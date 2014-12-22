using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.Model
{
    class Level
    {
        private float m_Speed = 0.01f;
       
        private Vector2 m_position1;
        private Vector2 m_position2;

        public float getLevelSpeed
        {
            get
            {
                return m_Speed;
            }
        }

        public void Update(GameTime timeElapsed,Vector2 a_position1,Vector2 a_position2, float vSpeed, float vy)
        {
            m_position1 = a_position1;
            m_position2 = a_position2;

            m_position2.Y = m_position2.Y + vSpeed;
            m_position1.Y = m_position1.Y + vSpeed;


            if (m_position1.Y >= vy)
            {
                m_position1.Y = 0;
                m_position2.Y = -vy;
            }
        }

        public Vector2 getPos1
        {
            get
            {
                return m_position1;
            }
        }

        public Vector2 getPos2
        {
            get
            {
                return m_position2;
            }
        }
    }
}

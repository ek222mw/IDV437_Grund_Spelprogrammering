using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb3.Model
{
    class Ball
    {
        public float m_diameter;
        public float m_x;
        public float m_y;

        public float m_speedX;
        public float m_speedY;

       
       
        private bool m_isDead;


        public Ball(float centerX, float centerY, float speedX, float speedY)
        {
            m_isDead = false;
            this.m_x = centerX;
            this.m_y = centerY;
            m_diameter = 0.03f;
            this.m_speedX = speedX;
            this.m_speedY = speedY;
        }

        public bool IsDead
        {
            get { return m_isDead; }
            set { m_isDead = value; }
        }

        public float CenterX
        {
            get { return m_x; }
            set { m_x = value; }
        }

        public float CenterY
        {
            get { return m_y; }
            set { m_y = value; }
        }

        public float Diameter
        {
            get { return m_diameter; }
            set { m_diameter = value; }
        }

        public float SpeedX
        {
            get { return m_speedX; }
            set { m_speedX = value; }
        }

        public float SpeedY
        {
            get { return m_speedY; }
            set { m_speedY = value; }
        }

    }
}

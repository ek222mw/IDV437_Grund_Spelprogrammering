using Microsoft.Xna.Framework;
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
        private float m_speed = 0.02f;
       
      

       

        public Asteroid()
        {

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

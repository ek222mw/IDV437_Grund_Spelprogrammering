using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt
{
    class Level
    {
        private float m_Speed = 0.01f;
        public float m_yBackGroundImg = 1.0f;
        public float m_xBackGroundImg = 0;


        public float getLevelSpeed
        {
            get
            {
                return m_Speed;
            }
        }
    }
}

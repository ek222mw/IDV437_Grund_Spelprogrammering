using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt
{
    class Bullet
    {
        private int m_speed = 10;
        private float m_DelayBullet = 20;

        public int getBulletSpeed
        {
            get
            {
                return m_speed;
            }
        }

        public float DelayTimeBullet
        {
            get
            {
                return m_DelayBullet;
            }
        }

        public float checkIfDelayGreaterThanZero()
        {
            if (DelayTimeBullet >= 0)
            {
                return m_DelayBullet--;
            }
            return m_DelayBullet;

        }

        public float checkIfDelayEqualToZero()
        {
            if (DelayTimeBullet == 0)
            {
                return m_DelayBullet = 20;
            }
            return m_DelayBullet;
        }
        

       
    }
}

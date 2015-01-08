using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.Model
{
    class Bullet
    {
        public Rectangle bulletHitBox;
        Texture2D m_bulletTexture;
        public Vector2 m_position;
        public bool isVisible;
        private float speed;

        public Bullet(Texture2D a_Bullettexture)
        {
            speed = 8;
            m_bulletTexture = a_Bullettexture;
            isVisible = false;

        }

        public Vector2 getPos()
        {
            return m_position;
        }

        public Rectangle getHitBox
        {
            get
            {
                return bulletHitBox;
            }
        }

        public float getSpeed
        {
            get
            {
                return speed;
            }
        }

        public Texture2D getTexture
        {
            get
            {
                return m_bulletTexture;
            }
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt
{
    class BulletView
    {

        public Texture2D m_texture;
        Rectangle m_boundingBox;
        Vector2 m_origin;
        public Vector2 m_position;
        public bool m_isVisible;
        public int m_speed;
        Bullet m_bullet;

        public BulletView(int a_width, int a_height,Texture2D a_texture)
        {
            m_texture = a_texture;
            m_isVisible = false;
            m_bullet = new Bullet();
            m_speed = m_bullet.m_speed;

           
        }

       

        public void Draw(SpriteBatch a_spriteBatch)
        {

            a_spriteBatch.Draw(m_texture, m_position, Color.White);

        }
    }
}

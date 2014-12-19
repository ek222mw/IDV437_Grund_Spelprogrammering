using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt
{
    class BulletSimulation
    {
        public List<Bullet> bulletList;
        public int bulletDelay = 1;
        public Vector2 m_bulletTextureScaled;
        Bullet newBullet;


        public BulletSimulation(Vector2 a_bulletTextureScaled) {

            m_bulletTextureScaled = a_bulletTextureScaled;
        }

        public List<Bullet> PlayerShoot(Vector2 position, List<Bullet>bulletList, Texture2D bulletTexture, Vector2 a_posCenterTexture)
         {

            this.bulletList = bulletList;


            if (bulletDelay >= 0)
            {
                bulletDelay--;
            }
            if (bulletDelay <= 0)
            {
                newBullet = new Bullet(bulletTexture);
                newBullet.m_position = new Vector2(position.X + a_posCenterTexture.X - m_bulletTextureScaled.X /2, position.Y + a_posCenterTexture.Y);
                newBullet.isVisible = true;

                if (bulletList.Count() < 20)
                {
                    bulletList.Add(newBullet);
                }
            }

            if (bulletDelay == 0)
            {
                bulletDelay = 10;
            }

            return bulletList;
        }

        public List<Bullet> UpdateBullet(List<Bullet> bulletList)
        {
            foreach (Bullet bullet in bulletList.ToList())
            {
                bullet.m_position.Y = bullet.m_position.Y - bullet.speed;

                if (bullet.m_position.Y <= 0)
                {
                    bullet.isVisible = false;
                }

                for (int i = 0; i < bulletList.Count; i++)
                {
                    if (!bulletList[i].isVisible)
                    {
                        bulletList.RemoveAt(i);
                        i--;
                    }
                }
            }
            return bulletList;
        }

       
    

    }
}

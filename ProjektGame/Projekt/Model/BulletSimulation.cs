using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Projekt.Model;
using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.Model
{
    class BulletSimulation
    {
        public List<Bullet> bulletList;
        public int bulletDelay = 1;
        public int enemyBulletDelay = 40;
        public List<Bullet> enemyBulletList;
        public Vector2 m_bulletTextureScaled;
        Bullet newBullet;


        public BulletSimulation(Vector2 a_bulletTextureScaled) {

            m_bulletTextureScaled = a_bulletTextureScaled;
        }

        public List<Bullet> PlayerShoot(Vector2 position, List<Bullet>bulletList, Texture2D bulletTexture, Vector2 a_posCenterTexture, Sound a_sound)
        {

            this.bulletList = bulletList;


            if (bulletDelay >= 0)
            {
                bulletDelay--;
            }
            if (bulletDelay <= 0)
            {
                a_sound.m_playerShoot.Play();
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

        public List<Bullet> UpdateBullet(List<Bullet> bulletList, Rectangle a_boundingbox)
        {
            foreach (Bullet bullet in bulletList.ToList())
            {
                a_boundingbox = new Rectangle((int)bullet.m_position.X, (int)bullet.m_position.Y, (int)bullet.m_bulletTexture.Width, (int)bullet.m_bulletTexture.Height);
                
                bullet.m_position.Y = bullet.m_position.Y - bullet.speed;
                bullet.bulletHitBox = a_boundingbox;

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

        public List<Bullet> UpdateEnemyBullet(List<Bullet> bulletList, Rectangle a_boundingbox)
        {
            foreach (Bullet bullet in bulletList.ToList())
            {
                a_boundingbox = new Rectangle((int)bullet.m_position.X, (int)bullet.m_position.Y, (int)bullet.m_bulletTexture.Width, (int)bullet.m_bulletTexture.Height);

                bullet.m_position.Y = bullet.m_position.Y + bullet.speed;
                bullet.bulletHitBox = a_boundingbox;

                if (bullet.m_position.Y >= 950)
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

        public List<Bullet> EnemyShoot(Vector2 position, List<Bullet> bulletList, Texture2D bulletTexture, Vector2 a_posCenterTexture)
        {

            enemyBulletList = bulletList;


            if (enemyBulletDelay >= 0)
            {
                enemyBulletDelay--;
            }
            if (enemyBulletDelay <= 0)
            {
                newBullet = new Bullet(bulletTexture);
                newBullet.m_position = new Vector2(position.X + a_posCenterTexture.X - m_bulletTextureScaled.X / 2, position.Y + a_posCenterTexture.Y);
                newBullet.isVisible = true;

                if (enemyBulletList.Count() < 20)
                {
                    bulletList.Add(newBullet);
                }
            }

            if (enemyBulletDelay == 0)
            {
                enemyBulletDelay = 40;
            }

            return bulletList;
        }

       
    

    }
}

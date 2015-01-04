using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.View
{
    class EnemyView
    {

        public void Draw(SpriteBatch a_spriteBatch,List<Bullet> a_bulletList, Texture2D a_bulletTexture, List<Enemy> a_enemyList)
        {
            foreach (Bullet b in a_bulletList)
            {
                a_spriteBatch.Draw(a_bulletTexture, b.getPos(), Color.White);
            }

            foreach (Enemy e in a_enemyList)
            {
                if (e.getIsVisible)
                {
                    a_spriteBatch.Draw(e.getTexture, e.getEnemyPos, Color.White);
                }

            }
        }
    }
}

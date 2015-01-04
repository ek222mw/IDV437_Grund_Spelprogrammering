using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.Model
{
    class EnemySimulation
    {

        Random random = new Random();
        private int m_windowWidth;
        private int m_windowHeight;
        Texture2D m_texture;
       
        


        public EnemySimulation(int a_width, int a_height)
        {
            m_windowWidth = a_width;
            m_windowHeight = a_height;

        }

        public void CreateEnemies(Texture2D a_Texture, List<Enemy> EnemyList, int numberOfEnemies)
        {
            m_texture = a_Texture;
            int randomX = random.Next(1, m_windowWidth);
            int randomY = random.Next(-m_windowHeight, -50);

            if (EnemyList.Count < numberOfEnemies)
            {
                EnemyList.Add(new Enemy(m_windowWidth, m_windowHeight, m_texture, new Vector2(randomX, randomY)));
            }

            for (int i = 0; i < EnemyList.Count; i++)
            {
                if (EnemyList[i].m_isVisible == false)
                {
                    EnemyList.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}

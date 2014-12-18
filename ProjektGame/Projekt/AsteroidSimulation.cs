using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt
{
    class AsteroidSimulation
    {
        Random random = new Random();
        private int m_windowWidth;
        private int m_windowHeight;
        Texture2D m_texture;
       
        


        public AsteroidSimulation(int a_width, int a_height)
        {
            m_windowWidth = a_width;
            m_windowHeight = a_height;

        }

        public void CreateAsteroids(Texture2D a_Texture, List<Asteroid> AsteroidList)
        {
            m_texture = a_Texture;
            int randomX = random.Next(1, m_windowWidth);
            int randomY = random.Next(-m_windowHeight, -50);

            if (AsteroidList.Count < 5)
            {
                AsteroidList.Add(new Asteroid(m_windowWidth, m_windowHeight, m_texture, new Vector2(randomX, randomY)));
            }

            for (int i = 0; i < AsteroidList.Count; i++)
            {
                if (AsteroidList[i].isVisible == false)
                {
                    AsteroidList.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}

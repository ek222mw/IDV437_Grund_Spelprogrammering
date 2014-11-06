using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game1
{
    class BallSimulation
    {
        public int width = 1;
        public int height = 1;

        
        Ball m_ball = new Ball();

        public BallSimulation()
        {

        }

        public int Level()
        {
            int[][] gamearea = new int[width][];
            for (int x = 0; x < width; x++)
            {
                gamearea[x] = new int[height];
                for (int y = 0; y < height; y++)
                {

                    return gamearea[x][y] = new int();
                }
            }
            return 1;
        }

        internal void Update(GameTime gameTime)
        {
           
          
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            m_ball.m_x += elapsedTime * m_ball.speedX;
            Console.WriteLine(m_ball.m_x);
            if (m_ball.m_x > 1.0f)
            {
                m_ball.m_x -= 1.0f;
        
            }


        }
        
    }
}

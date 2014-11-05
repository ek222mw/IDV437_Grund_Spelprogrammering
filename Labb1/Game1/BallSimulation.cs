using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    class BallSimulation
    {
        public int width = 1;
        public int height = 1;

        public int[][] gamearea;
        Ball m_ball;

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

        public bool update(float timeElapsedSeconds)
        {
            m_ball = new Ball();
            m_ball.centerX = m_ball.centerX + m_ball.speedX * timeElapsedSeconds;

            if (m_ball.centerX + m_ball.diameter / 2 > width)
            {
                m_ball.speedX = m_ball.speedX * -1.0f;
            }
            if (m_ball.centerX - m_ball.diameter / 2 < 0)
            {
                m_ball.speedX = m_ball.speedX * -1.0f;
            }

            m_ball.centerY = m_ball.centerY + m_ball.speedY * timeElapsedSeconds;


            if (m_ball.centerY - m_ball.diameter / 2 < 0)
            {
                m_ball.speedY = m_ball.speedY * -1.0f;
            }

            if (m_ball.centerY + m_ball.diameter / 2 > height)
            {
                return true;
            }

            if (m_ball.centerY + m_ball.diameter / 2 > height)
            {
                return true;
            }

            return false;
        }
        
    }
}

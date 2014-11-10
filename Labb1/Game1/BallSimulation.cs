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




        public BallSimulation()
        {

        }


        internal void Update(GameTime gameTime, Ball m_ball)
        {


            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

           
            Console.WriteLine(m_ball.m_x);

            m_ball.m_x += elapsedTime * m_ball.speedX;
            m_ball.m_y += elapsedTime * m_ball.speedY;


            if (m_ball.m_x > 1.0f - m_ball.diameter)
            {
                m_ball.speedX = m_ball.speedX * -1.0f;
            }

            if (m_ball.m_x < 0.0f + m_ball.diameter * 2)
            {
                m_ball.speedX = m_ball.speedX * -1.0f;

            }

            if (m_ball.m_y > 1.0f - m_ball.diameter)
            {
                m_ball.speedY = m_ball.speedY * -1.0f;
            }

            if (m_ball.m_y < 0.0f + m_ball.diameter * 2)
            {
                m_ball.speedY = m_ball.speedY * -1.0f;
            }

            }

        }
    }


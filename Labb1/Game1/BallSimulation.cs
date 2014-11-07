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
            
            m_ball.m_x += elapsedTime * m_ball.speedX;
            Console.WriteLine(m_ball.m_x);
            if (m_ball.m_x > 1.0f)
            {
                m_ball.m_x -= 1.0f;
        
            }


        }
        
    }
}

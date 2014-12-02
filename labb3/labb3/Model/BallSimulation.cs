using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb3.Model
{
    class BallSimulation
    {
        public int width = 1;
        public int height = 1;
        public List<Ball> m_ballList;
        private int m_numberOfBalls = 10;
        float m_mouseDiameter = 0.1f;

        public BallSimulation()
        {
            m_ballList = new List<Ball>();
            Random random = new Random();

            for (int i = 0; i < m_numberOfBalls; i++)
            {
                //(random maxpos, minpos on balls)
                float m_centerX = (float)random.NextDouble() * (1.0f - 0.5f) + 0.1f;
                float m_centerY = (float)random.NextDouble() * (1.0f - 0.5f) + 0.1f;

                //(random maxspeed, minspeed on balls)
                float m_speedX = (float)random.NextDouble() * (0.7f - 0.2f) + 0.1f;
                float m_speedY = (float)random.NextDouble() * (0.7f - 0.1f) + 0.1f;

                m_ballList.Add(new Ball(m_centerX, m_centerY, m_speedX, m_speedY));
            }
        }
        public void ballsInsideShootArea(Vector2 mousePos)
        {
            foreach (var ball in m_ballList)
            {   //Räknar ut en linje till partiklarna
                float m_dx = ball.CenterX - mousePos.X;
                float m_dy = ball.CenterY - mousePos.Y;
                float m_length = (float)Math.Sqrt(m_dx * m_dx + m_dy * m_dy);

                if (m_length < m_mouseDiameter / 2)
                {
                    ball.IsDead = true;
                }
            }
        }


        internal void Update(GameTime gameTime)
        {


            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;


            foreach (var ball in m_ballList)
            {
                if (!ball.IsDead)
                {

                    ball.m_x += elapsedTime * ball.m_speedX;
                    ball.m_y += elapsedTime * ball.m_speedY;


                    if (ball.m_x + ball.m_diameter / 2 > 1.0f)
                    {
                        ball.m_speedX = ball.m_speedX * -1.0f;
                    }

                    if (ball.m_x - ball.m_diameter / 2 < 0.0f)
                    {
                        ball.m_speedX = ball.m_speedX * -1.0f;

                    }

                    if (ball.m_y + ball.m_diameter / 2 > 1.0f)
                    {
                        ball.m_speedY = ball.m_speedY * -1.0f;
                    }

                    if (ball.m_y - ball.m_diameter / 2 < 0.0f)
                    {
                        ball.m_speedY = ball.m_speedY * -1.0f;
                    }
                }
            }

        }
        public float getShootDiameter
        {
            get { return m_mouseDiameter; }
        }

    }
}

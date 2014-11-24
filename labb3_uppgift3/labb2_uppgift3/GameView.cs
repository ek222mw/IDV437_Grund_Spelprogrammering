using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb2_uppgift3
{
    class GameView
    {
        /*private Rectangle scrRect; 
        private float timeElapsed;
        private float delay = 0.2f;
        private int framesX;
        private int framesY;
        private int maxframesY;

        public GameView()
        {


        }

        public void Update(float elapsedTime)
        {
            timeElapsed += elapsedTime;

            if (timeElapsed >= delay)
            {
                if (framesX >= 3)
                {
                    maxframesY++;                   
                    framesX = 0;
                    framesY += 128;
                }
                else
                {
                    framesX++;
                }
                if (maxframesY >= 5)
                {
                    maxframesY = 0;
                    framesY -= 640;
                }
                
                timeElapsed = 0;
            }

            scrRect = new Rectangle(128*framesX,128+framesY,128,128);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D m_texture2d, Rectangle destRect)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(m_texture2d, destRect, scrRect, Color.White);

            spriteBatch.End();

        }*/
    }
}

using labb3.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb3.View
{
    class BallView
    {

        private GraphicsDevice GraphicsDevice;
        private Microsoft.Xna.Framework.Content.ContentManager Content;
        private SpriteBatch m_spriteBatch;
        private Texture2D m_ballTexture;
        private int scale;
        BallSimulation m_ballSimulation = new BallSimulation();
        Camera m_camera; 

        private int m_windowWidth;
        private int m_windowHeight;

        public BallView(GraphicsDevice GraphicsDevice, ContentManager Content)
        {
            // TODO: Complete member initialization
            this.GraphicsDevice = GraphicsDevice;
            this.Content = Content;
            this.m_windowWidth = GraphicsDevice.Viewport.Width;
            this.m_windowHeight = GraphicsDevice.Viewport.Height;
            m_camera = new Camera(m_windowWidth, m_windowHeight);
            m_camera.setDimensionstask4(m_windowWidth, m_windowHeight);
            
            m_spriteBatch = new SpriteBatch(GraphicsDevice);


        }

        internal void drawball(Ball m_ball, int framesize)
        {

            float balldiameter;
            m_ballTexture = Content.Load<Texture2D>("ball");

            scale = m_camera.getScale();
            balldiameter = m_ball.diameter;

            int vx = (int)(m_ball.m_x * m_camera.getScale() + framesize);
            int vy = (int)(m_ball.m_y * m_camera.getScale() + framesize);
            int ballSize = (int)(balldiameter * scale);

            Rectangle destrect = new Rectangle(vx - ballSize / 2, vy - ballSize / 2, ballSize, ballSize);


            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_ballTexture, destrect, Color.White);
            m_spriteBatch.End();
        }

        internal void drawLevel(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor, Texture2D pixel)
        {


            m_ballTexture = Content.Load<Texture2D>("level");

            int addframeX = 0;
            int addframeY = 0;

            if (rectangleToDraw.Height > rectangleToDraw.Width)
            {
                addframeX = rectangleToDraw.Height - rectangleToDraw.Width;
            }
            if (rectangleToDraw.Width > rectangleToDraw.Height)
            {
                addframeY = rectangleToDraw.Width - rectangleToDraw.Height;
            }


            Rectangle destrect = new Rectangle(0, 0, m_windowWidth, m_windowHeight);


            m_spriteBatch.Begin();

            //Draw Background
            m_spriteBatch.Draw(m_ballTexture, destrect, Color.White);

            // Draw top line
            m_spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line
            m_spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line
            m_spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder - addframeY),
                                               rectangleToDraw.Y,
                                               thicknessOfBorder + addframeY,
                                               rectangleToDraw.Height), borderColor);

            // Draw bottom line
            m_spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                           rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder - addframeX,
                                           rectangleToDraw.Width,
                                           thicknessOfBorder + addframeX), borderColor);
            m_spriteBatch.End();



        }


		

    }
}

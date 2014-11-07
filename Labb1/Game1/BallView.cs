using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game1
{
    class BallView
    {
        private GraphicsDevice GraphicsDevice;
        private Microsoft.Xna.Framework.Content.ContentManager Content;
        private SpriteBatch m_spriteBatch;
        private Texture2D m_ballTexture;
        private int scale;
        BallSimulation m_ballSimulation = new BallSimulation();
        Camera m_camera = new Camera();
       
        private int m_windowWidth;
        private int m_windowHeight;

        public BallView(GraphicsDevice GraphicsDevice, ContentManager Content)
        {
            // TODO: Complete member initialization
            this.GraphicsDevice = GraphicsDevice;
            this.Content = Content;
            this.m_windowWidth = GraphicsDevice.Viewport.Width;
            this.m_windowHeight = GraphicsDevice.Viewport.Height;


            m_spriteBatch = new SpriteBatch(GraphicsDevice);

            m_ballTexture = Content.Load<Texture2D>("ball");
        }

        internal void drawPostion()
        {
            Vector2 screenpos;
            
            

            Vector2 modelpos = new Vector2(7.0f,7.0f);
            screenpos = m_camera.getViewPos(modelpos);
            
           // Console.WriteLine(screenpos.X);
            
        }

        internal void drawreverse()
        {
            
            Vector2 rotation;
            Vector2 modelpos = new Vector2(7.0f, 7.0f);
            rotation = m_camera.getRotation(modelpos);

            //Console.WriteLine(rotation.X);
            
           
        }

        internal void drawscaled()
        {
            
           
            int scaleWidthX = 640;
            int scaleHeightY = 640;

            scale = m_camera.setDimensions(scaleWidthX, scaleHeightY);

            Console.WriteLine(scale);
            
        }

        internal void drawball(Ball m_ball)
        {
            

            int vx = (int)(m_ball.m_x * m_windowWidth);
            int vy = (int)(m_ball.m_y * m_windowHeight);

            Rectangle destrect = new Rectangle(vx-15,vy-15, 30, 30);
            

            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_ballTexture, destrect, Color.Red);
            m_spriteBatch.End();
        }

        internal void drawLevel() {

            
            
            scale = m_camera.setDimensionstask4(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

           m_ballTexture = Content.Load<Texture2D>("level");

		for  (int x = 0; x < m_ballSimulation.width; x++) {
			for (int y = 0; y < m_ballSimulation.height; y++)  {
				int w = scale;
				int h = scale;
				
					int vx = m_camera.toViewX(x);
					int vy = m_camera.toViewY(y);

                    Rectangle destrect = new Rectangle(vx, vy,w,h);
       

                    m_spriteBatch.Begin();
                    m_spriteBatch.Draw(m_ballTexture, destrect, Color.White);
                    m_spriteBatch.End();
					
				
			}
		}

		
			
		
	}
    }
}

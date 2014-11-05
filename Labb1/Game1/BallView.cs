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
        private float scale;
        BallSimulation m_ballSimulation;
        Camera m_camera;
        Ball m_ball;
        


        public BallView(GraphicsDevice GraphicsDevice, ContentManager Content)
        {
            // TODO: Complete member initialization
            this.GraphicsDevice = GraphicsDevice;
            this.Content = Content;

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

        internal void drawball()
        {
            Camera m_camera = new Camera();
            m_ball = new Ball();
            Rectangle destrect = new Rectangle(10, 10, 20, 30);
            scale = m_camera.setDimensions(m_ballSimulation.width, m_ballSimulation.height);

            float vx = m_camera.toViewX(m_ball.centerX);
            float vy = m_camera.toViewY(m_ball.centerY);
            float vBallSize = m_ball.diameter * scale;
            
            m_spriteBatch.Begin();
            m_spriteBatch.Draw(m_ballTexture, destrect, Color.White);
            m_spriteBatch.End();
        }

        internal void drawLevel() {

            m_ballSimulation = new BallSimulation();
            m_camera = new Camera();

		for  (int x = 0; x < m_ballSimulation.width; x++) {
			for (int y = 0; y < m_ballSimulation.height; y++)  {
				float w = scale;
				float h = scale;
				
					float vx = m_camera.toViewX(x);
					float vy = m_camera.toViewY(y);

                    Vector2 destrect = new Vector2(vx, vy);
       

                    m_spriteBatch.Begin();
                    m_spriteBatch.Draw(m_ballTexture, destrect, Color.White);
                    m_spriteBatch.End();
					
				
			}
		}

		//top left is 0, 0
			
		
	}
    }
}

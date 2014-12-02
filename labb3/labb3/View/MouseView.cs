using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb3.View
{
    class MouseView
    {
        
       
        private SpriteBatch m_spriteBatch;
        Camera m_camera;

        public MouseView(GraphicsDevice graphicsDevice, Camera a_camera)
        {
            m_camera = a_camera;
            m_spriteBatch = new SpriteBatch(graphicsDevice);
        }

        internal void drawMouseAim(Texture2D aimTexture, float MouseDiameter, MouseState currentMouseState)
        {
            int mouseDiameter = (int)(MouseDiameter * m_camera.getScaleExplotion());

            Rectangle mouseAim = new Rectangle(currentMouseState.X - mouseDiameter / 2, currentMouseState.Y - mouseDiameter / 2, mouseDiameter, mouseDiameter);

            m_spriteBatch.Begin();
            m_spriteBatch.Draw(aimTexture, mouseAim, Color.White);
            m_spriteBatch.End();
        }
    }
}

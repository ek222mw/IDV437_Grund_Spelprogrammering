using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace Controller_Labb2
{
    class Camera
    {
        private int scale;
        private int width;
        private int height;
        private int m_border = 10;

        public Camera(int a_width, int a_height)
        {

            int ScaleY = (a_height - m_border * 2);
            int ScaleX = (a_width - m_border * 2);

            scale = ScaleX;
            if (ScaleY < ScaleX)
            {
                scale = ScaleY;
            }

        }

        
       

      

        public void setDimensionstask4(int width, int height)
        {
            this.width = width;
            this.height = height;
            
            //int scaleX = (width - borderSizetask4 * 2);
            //int scaleY = (height - borderSizetask4 * 2);

            //scale = scaleX;
            //if (scaleY < scaleX)
            //{
            //    scale = scaleY;
            //}

        }

        public int getScale()
        {
            return scale;
        }

        public Rectangle ScaleParticles(float posX, float posY, float a_sizeSplitter)
        {

            int ViewX = (int)(posX * scale + m_border);
            int ViewY = (int)(posY * scale + m_border);

            int ViewSize = (int)(a_sizeSplitter * scale);

            return new Rectangle(ViewX, ViewY, ViewSize, ViewSize);

           
        }
    }
}

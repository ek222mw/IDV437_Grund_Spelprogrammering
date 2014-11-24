using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb2_uppgift2
{
    class Camera
    {
        private int scale;
       // private int width;
        //private int height;
        private int m_border = 10;
        
        public Camera(int a_width,int a_height)
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
            //this.width = width;
            //this.height = height;

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

        public Vector2 ScaleParticles(float posX, float posY)
        {

            float ViewX = (posX * scale + m_border);
            float ViewY = (posY * scale + m_border);

            //int ViewSize = (int)(a_sizeSplitter * scale);

            return new Vector2(ViewX, ViewY);


        }


    }
}

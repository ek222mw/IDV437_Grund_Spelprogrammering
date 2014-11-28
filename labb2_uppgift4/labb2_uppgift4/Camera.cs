using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb2_uppgift4
{
    class Camera
    {

        //private int scale;
        private int width;
        private int height;
        private int m_border = 10;
        private float scale;
        private int border = 10;


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

        //public int getScale()
        //{
        //    return scale;
        //}

        public Rectangle ScaleParticles(float posX, float posY, float a_sizeSplitter)
        {

            int ViewX = (int)(posX * scale + m_border);
            int ViewY = (int)(posY * scale + m_border);

            int ViewSize = (int)(a_sizeSplitter * scale);

            return new Rectangle(ViewX, ViewY, ViewSize, ViewSize);


        }
        public Vector2 scaleVec(float xPos, float yPos)
        {
            float m_X = (xPos * scale + border);
            float m_Y = (yPos * scale + border);

            return new Vector2(m_X, m_Y);
        }

        public float getScale()
        {
            return scale;
        }

        public Vector2 ScaleParticlesSmoke(float posX, float posY)
        {

            float ViewX = (posX * scale + m_border);
            float ViewY = (posY * scale + m_border);

            //int ViewSize = (int)(a_sizeSplitter * scale);

            return new Vector2(ViewX, ViewY);


        }




    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb3.View
{
    class Camera
    {

        private int scale;
        private int width;
        private int height;
        private int m_border = 10;
        private int scaleBall;
       
        private int borderSizetask4 = 20;
        
        private static int border = 10;
        private int displacementX = 0;
        private int displacementY = 0;

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

        public Vector2 getModelCoordinates(float viewX, float viewY)
        {
            float modelX = (viewX - displacementX) / scale;
            float modelY = (viewY - displacementY) / scale;

            return new Vector2(modelX, modelY);

        }






        public void setDimensionstask4(int width, int height)
        {
            this.width = width;
            this.height = height;

            int scaleX = (width - borderSizetask4 * 2);
            int scaleY = (height - borderSizetask4 * 2);

            scaleBall = scaleX;
            if (scaleY < scaleX)
            {
                scaleBall = scaleY;
            }

        }

        public int getScale()
        {
            return scaleBall;
        }

        public Rectangle ScaleParticles(float posX, float posY, float a_sizeSplitter)
        {

            int ViewX = (int)(posX * scale + m_border);
            int ViewY = (int)(posY * scale + m_border);

            int ViewSize = (int)(a_sizeSplitter * scale);

            return new Rectangle(ViewX, ViewY, ViewSize, ViewSize);


        }

        public Vector2 ScaleParticlesSmoke(float posX, float posY)
        {

            float ViewX = (posX * scale + m_border);
            float ViewY = (posY * scale + m_border);

            //int ViewSize = (int)(a_sizeSplitter * scale);

            return new Vector2(ViewX, ViewY);


        }

        public Vector2 scaleVec(float xPos, float yPos)
        {
            float m_X = (xPos * scale + border);
            float m_Y = (yPos * scale + border);

            return new Vector2(m_X, m_Y);
        }

        public float getScaleExplotion()
        {
            return scale;
        }

    }
}

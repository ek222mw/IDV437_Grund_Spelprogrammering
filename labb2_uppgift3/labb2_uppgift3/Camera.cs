using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb2_uppgift3
{
    class Camera
    {
        private float scale;
        private static int border = 10;

        public Camera(int width, int heigth)
        {
            int scaleX = (width - border * 2);
            int scaleY = (heigth - border * 2);

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
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
    }
}

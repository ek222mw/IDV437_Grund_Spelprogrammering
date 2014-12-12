using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt
{
        class Camera
        {
            private float scale;
            private int width;
           

            public Camera(int a_width, int a_height)
            {

                float ScaleY = (a_height);
                float ScaleX = (a_width);

                scale = ScaleX;
                if (ScaleY < ScaleX)
                {
                    scale = ScaleY;
                }

            }

            public float getScale()
            {
                return scale;
            }
        }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt
{
        class Camera
        {
            private float scale;
           
            private int m_width;
            private int m_height;
            private float scaleDiff;

            public Camera(int a_width, int a_height)
            {

                float ScaleY = (a_height);
                float ScaleX = (a_width);

                scale = ScaleX;
                if (ScaleY < ScaleX)
                {
                    scale = ScaleY;
                }

                scaleDiff = ScaleY - ScaleX;

            }

            public Vector2 getViewPosPic(Vector2 modelpos, Texture2D a_texture)
            {

                float textureWidth = a_texture.Width / scale;
                float textureHeight = a_texture.Height / (scale+scaleDiff);

                float vx = scale * (modelpos.X - textureWidth);
                float vy = (scale+scaleDiff) * (modelpos.Y - textureHeight);

                return new Vector2(vx, vy);
                 
            }

            public float getScale()
            {
                return scale;
            }
        }
}

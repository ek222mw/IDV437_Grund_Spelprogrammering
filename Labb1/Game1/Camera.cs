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
    class Camera
    {
        private int width;
        private int height;
        private int sizeOfTile = 64;
        private int borderSize = 64;
        
        private int scale;

        public Camera()
        {
           
        }

        
        public Vector2 getViewPos(Vector2 modelCenter)
        {
           
            

            float visualX = borderSize + modelCenter.X * sizeOfTile;
            float visualY = borderSize + modelCenter.Y * sizeOfTile;

            return new Vector2(visualX,visualY);
        }

        public Vector2 getRotation(Vector2 modelCenter)
        {
            const int maxXcoordinate = 7;
            const int maxYCoordinate = 7;
            float ReverseX;
            float ReverseY;
            
            ReverseX = maxXcoordinate - modelCenter.X;
            ReverseY = maxYCoordinate - modelCenter.Y;

            float visualX = borderSize + ReverseX * sizeOfTile;
            float visualY = borderSize + ReverseY * sizeOfTile;

            return new Vector2(visualX, visualY);
        }

        public int setDimensions(int width, int height)
        {
            this.width = width;
            this.height = height;
            int sizeOfTilefull = sizeOfTile * 8;
            int borderSizefull = borderSize * 2;

            int scaleX = (width - borderSizefull) / sizeOfTilefull;
            int scaleY = (height - borderSizefull) / sizeOfTilefull;
            

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }

            return scale;
        }

        public float toViewX(float x)
        {
            return x * scale + borderSize;
        }

        public float toViewY(float y)
        {
            return y * scale + borderSize;
        }




    }
}

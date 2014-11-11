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
        private int borderSizetask4 = 20;
        
        private int scale;
        private int scaleTask3;

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

        public void setDimensions(int width, int height)
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
                scaleTask3 = scaleY;
            }

           
        }

        public void setDimensionstask4(int width, int height)
        {
            this.width = width;
            this.height = height;
            
            int scaleX = (width - borderSizetask4 * 2);
            int scaleY = (height - borderSizetask4 * 2);

            scaleTask3 = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }

        }

        public int getScale()
        {
            return scale;
        }

        public int getScaleTask3()
        {
            return scaleTask3;
        }

        public int toViewX(int x)
        {
            return x * scale + borderSize;
        }

        public int toViewY(int y)
        {
            return y * scale + borderSize;
        }

        




    }
}

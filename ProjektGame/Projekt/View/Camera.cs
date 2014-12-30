using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.View
{
        class Camera
        {
            private float scale;
           
           
            private float scaleDiffHeight;
            private float scaleDiffWidth;
            private float ScaleY;
            private float ScaleX;
            private float vx;
            private float vy;
            private float textureWidth;
            private float textureHeight;
            Ship m_ship;
            Level m_level;
            Asteroid m_asteroid;

            public Camera(int a_width, int a_height)
            {

                m_ship = new Ship();
                m_level = new Level();
                m_asteroid = new Asteroid();
                ScaleY = a_height;
                ScaleX = a_width;
                
                scale = ScaleX;
                if (ScaleY < ScaleX)
                {
                    scale = ScaleY;
                }
            }

            public Vector2 getMaxViewPosShipTexture(Texture2D a_texture)
            {

                scaleDiffWidth = ScaleX - ScaleY;
                scaleDiffHeight = ScaleY - ScaleX;


                if (ScaleY < ScaleX)
                {
                    textureWidth = a_texture.Width / (scale + scaleDiffWidth);
                    textureHeight = a_texture.Height / scale;

                    vx = (scale + scaleDiffWidth) * (m_ship.ShipMaxCanMove.X - textureWidth);
                    vy = scale * (m_ship.ShipMaxCanMove.Y - textureHeight);
                }
                else
                {
                    textureWidth = a_texture.Width / scale;
                    textureHeight = a_texture.Height / (scale+scaleDiffHeight);

                    vx = scale * (m_ship.ShipMaxCanMove.X - textureWidth);
                    vy = (scale+scaleDiffHeight) * (m_ship.ShipMaxCanMove.Y - textureHeight);
                }

                return new Vector2(vx, vy);
                 
            }

            public Vector2 getViewLevelTexture(Texture2D a_texture)
            {
                float Levelx;
                float Levely;
                float vx;
                float vy;
                float scaleDiffWidth = ScaleX - ScaleY;
                float scaleDiffHeight = ScaleY - ScaleX;

                if (ScaleY < ScaleX)
                {

                    Levelx = a_texture.Width / (scale + scaleDiffWidth);
                    Levely = a_texture.Height / scale;
                    vx = (scale + scaleDiffWidth) * Levelx;
                    vy = scale * Levely;
                }
                else
                {
                    Levelx = a_texture.Width / scale;
                    Levely = a_texture.Height / (scale+scaleDiffHeight);
                    vx = scale * Levelx;
                    vy = (scale+scaleDiffHeight) * Levely;
                }
                return new Vector2(vx, vy);
            }

            public float getLevelSpeed()
            {
               return m_level.getLevelSpeed * scale;
            }

            public float getScale()
            {
                return scale;
            }

            public float getAsteroidPosX()
            {
               return m_asteroid.getPosX * scale;
            }

            public float getAsteroidPosY()
            {
                return m_asteroid.getPosY * scale;
            }

            public float getAsteroidSpeed()
            {
                return m_asteroid.getSpeed * scale;
            }

            public Vector2 getScaledBulletTexture(Texture2D a_BulletTexture)
            {
                float BulletX;
                float BulletY;
               
                float scaleDiffWidth = ScaleX - ScaleY;
                float scaleDiffHeight = ScaleY - ScaleX;


                if (ScaleY < ScaleX)
                {
                    BulletX = a_BulletTexture.Width / (scale + scaleDiffWidth);
                    BulletY = a_BulletTexture.Height / scale;
                    
                }
                else
                {
                    BulletX = a_BulletTexture.Width / scale;
                    BulletY = a_BulletTexture.Height / (scale+scaleDiffHeight);
                }
         
                return new Vector2(BulletX, BulletY);
            }

            public Vector2 getShipTextureScaled(Texture2D a_texture)
            {
                float X;
                float Y;
                float vx;
                float vy;
                float scaleDiffWidth = ScaleX - ScaleY;
                float scaleDiffHeight = ScaleY - ScaleX;

                if (ScaleY < ScaleX)
                {
                    X = a_texture.Width / (scale + scaleDiffWidth);
                    Y = a_texture.Height / scale;
                    vx = (scale + scaleDiffWidth) * X;
                    vy = scale * Y;

                }
                else
                {
                    X = a_texture.Width / scale;
                    Y = a_texture.Height / (scale + scaleDiffHeight);
                    vx = scale * X;
                    vy = (scale + scaleDiffHeight) * Y;


                }

                return new Vector2(vx, vy);

            }
            public Vector2 getBulletPosMiddleOfShipTexture(Texture2D a_texture)
            {
                float X;
                float Y;
                float vx;
                float vy;
                float scaleDiffWidth = ScaleX - ScaleY;
                float scaleDiffHeight = ScaleY - ScaleX;
               
                if (ScaleY < ScaleX)
                {
                    X = a_texture.Width / (scale+scaleDiffWidth);
                    Y = a_texture.Height / scale;
                    vx = (scale+scaleDiffWidth) * (X/2.3f);
                    vy = scale * (Y/2);

                    
                }
                else
                {
                    X = a_texture.Width / scale;
                    Y = a_texture.Height / (scale + scaleDiffHeight);
                    vx = scale * (X/2.3f);
                    vy = (scale + scaleDiffHeight) * (Y/2);

                }

                return new Vector2(vx, vy);
            }

            public Vector2 getHealthBarPos()
            {
                float X;
                float Y;
                float vx;
                float vy;
                float scaleDiffWidth = ScaleX - ScaleY;
                float scaleDiffHeight = ScaleY - ScaleX;

                if (ScaleY < ScaleX)
                {
                    X = 25 / (scale + scaleDiffWidth);
                    Y = 25 / scale;
                    vx = (scale + scaleDiffWidth) * X;
                    vy = scale * Y;


                }
                else
                {
                    X = 25 / scale;
                    Y = 25 / (scale + scaleDiffHeight);
                    vx = scale * X;
                    vy = (scale + scaleDiffHeight) * Y; 

                }

                return new Vector2(vx, vy);
            }

            public float getHealthScaled(float health)
            {
                float healthLogic = health / scale;
                return healthLogic * scale;
            }

            public float getHealthBarHeight(Texture2D a_texture)
            {
                
                float Y;
                float vy;
                float scaleDiffHeight = ScaleY - ScaleX;

                if (ScaleY < ScaleX)
                {
                   
                    Y = a_texture.Height / scale;
                    
                    vy = scale * Y;


                }
                else
                {
                   
                    Y = a_texture.Height / (scale + scaleDiffHeight);
                    vy = (scale + scaleDiffHeight) * Y;

                }

                return vy;
            }

            public Vector2 getShipPosScaled()
            {
                float vx = m_ship.getShipPosX * scale;
                float vy = m_ship.getShipPosY * scale;

                return new Vector2(vx, vy);
            }
        }
}

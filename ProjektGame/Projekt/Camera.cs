﻿using Microsoft.Xna.Framework;
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
                float Levelx = a_texture.Width / scale;
                float Levely = a_texture.Height / scale;
                return new Vector2(Levelx, Levely);
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

            public Vector2 getBulletPosMiddleOfShipTexture(Texture2D a_texture)
            {
                float X;
                float Y;
                float vx;
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
        }
}

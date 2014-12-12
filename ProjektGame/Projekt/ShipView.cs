using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Projekt
{
    class ShipView
    {
        private Texture2D m_texture;
        private Vector2 m_position;
        private int Speed;

        public Rectangle m_boundingBox;
        public bool isColliding;
        Camera m_camera;
        Ship m_ship;
        private float m_scale;
        Level m_level;
        private float vx;
        private float vy;
        private  int m_windowWidth;
        private  int m_windowHeight;

        public ShipView(int Width, int Height)
        {
            m_windowWidth = Width;
            m_windowHeight = Height;
            m_texture = null;
            m_camera = new Camera(Width, Height);
            m_ship = new Ship();
            m_scale = m_camera.getScale();
            vx = m_ship.m_x * m_scale;
            vy = m_ship.m_y * m_scale;
            m_position = new Vector2(vx, vy);
           
            
            Speed = 10;
            isColliding = false;

        }

        public void LoadContent(ContentManager a_content)
        {
            m_texture = a_content.Load<Texture2D>("ship");

        }

        public void Update(GameTime timeElapsed)
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.W))
            {
                m_position.Y = m_position.Y - Speed;
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                m_position.X = m_position.X - Speed;
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                m_position.Y = m_position.Y + Speed;
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                m_position.X = m_position.X + Speed;
            }
            //Få skeppet att stanna innanför ramen.
            if (m_position.X <= 0)
            {
                m_position.X = 0;
            }

            if (m_position.X >= m_windowWidth - m_texture.Width)
            {
                m_position.X = m_windowWidth - m_texture.Width;
            }

            if (m_position.Y <= 0)
            {
                m_position.Y = 0;
            }

            if (m_position.Y >= m_windowHeight - m_texture.Height)
            {
                m_position.Y = m_windowHeight - m_texture.Height;
            }

        }

        public void Draw(SpriteBatch a_spriteBatch)
        {
           
            a_spriteBatch.Draw(m_texture, m_position, Color.White);
        }


    }





}

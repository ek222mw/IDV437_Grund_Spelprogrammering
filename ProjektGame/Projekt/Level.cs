using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt
{
    class Level
    {

        private Texture2D m_texture;
        private Vector2 m_position1,m_position2;
        private int Speed;
        private int m_Height;
        private int m_Width;
        
        Camera m_camera;
        Ship m_ship;
        private float m_scale;
        
        public Level(int Width, int Height)
        {
            m_Height = Height;
            m_Width = Width;

            m_position1 = new Vector2(0, 0);
            m_position2 = new Vector2(0, -m_Height);
           
            Speed = 5;

        }

        public void LoadContent(ContentManager a_content)
        {
           m_texture = a_content.Load<Texture2D>("space");

        }

        public void Update(GameTime timeElapsed)
        {
            
            m_position1.Y = m_position1.Y + Speed;
            m_position2.Y = m_position2.Y + Speed;
            if (m_position1.Y >= m_Height)
            {
                m_position1.Y = 0;
                m_position2.Y = -m_Height;
            }
        }

        public void Draw(SpriteBatch a_spriteBatch)
        {
           
           a_spriteBatch.Draw(m_texture, m_position1, Color.White);
           a_spriteBatch.Draw(m_texture, m_position2, Color.White);

        }
    }
}

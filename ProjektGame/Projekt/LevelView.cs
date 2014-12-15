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
    class LevelView
    {

        private Texture2D m_texture;
        private Vector2 m_position1,m_position2;
        
        private int m_Height;
        private int m_Width;
        
        Camera m_camera;
        Level m_level;
        private float vy;
        private float vx;
        private float vSpeed;
        
        public LevelView(int Width, int Height)
        {
            m_Height = Height;
            m_Width = Width;
            m_level = new Level();
            m_camera = new Camera(Width, Height);
            vy = m_camera.getScale() * m_level.m_yBackGroundImg;
            vx = m_camera.getScale() * m_level.m_xBackGroundImg;

            vSpeed = m_camera.getScale() * m_level.m_Speed;
            m_position1 = new Vector2(vx, 0);
            m_position2 = new Vector2(vx, -vy);
    
        }

        public void LoadContent(ContentManager a_content)
        {
           m_texture = a_content.Load<Texture2D>("space");

        }

        public void Update(GameTime timeElapsed)
        {
            m_position2.Y = m_position2.Y + vSpeed;
            m_position1.Y = m_position1.Y + vSpeed;
            

            if (m_position1.Y >= vy)
            {
                m_position1.Y = 0;
                m_position2.Y = -vy;
            }
        }

        public void Draw(SpriteBatch a_spriteBatch)
        {
           
           a_spriteBatch.Draw(m_texture, m_position1, Color.White);
           a_spriteBatch.Draw(m_texture, m_position2, Color.White);

        }
    }
}

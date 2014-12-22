using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projekt.Model;
using Projekt.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.Controller
{
    class LevelController
    {

        private Texture2D m_texture;
        private Vector2 m_position1,m_position2;
        
        private int m_Height;
        private int m_Width;
        
        Camera m_camera;
        Level m_level;
        Vector2 pos;
        private float vSpeed;
        LevelView m_levelView;
        
        
        public LevelController(int Width, int Height)
        {
            m_Height = Height;
            m_Width = Width;
            m_level = new Level();
            m_camera = new Camera(Width, Height);
            m_levelView = new LevelView();



           
            vSpeed = m_camera.getLevelSpeed();
            
    
        }

        public void LoadContent(ContentManager a_content)
        {
           m_texture = a_content.Load<Texture2D>("space");
           pos = m_camera.getViewLevelTexture(m_texture);

           m_position1 = new Vector2(0, 0);
           m_position2 = new Vector2(0, -pos.Y);
           
        }

        public void Update(GameTime timeElapsed)
        {
           
            m_level.Update(timeElapsed, m_position1, m_position2, vSpeed, pos.Y);
            m_position1 = m_level.getPos1;
            m_position2 = m_level.getPos2;
            
        }

        public void Draw(SpriteBatch a_spriteBatch)
        {

            m_levelView.Draw(a_spriteBatch, m_position1, m_position2, m_texture);

        }
    }
}

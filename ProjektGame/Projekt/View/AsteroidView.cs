﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.View
{
    class AsteroidView
    {
        
        

        public AsteroidView()
        {
        }




        public void Draw(SpriteBatch a_spriteBatch, bool a_isVisible, Vector2 a_position,Texture2D a_texture )
        {

            Vector2 m_position = a_position;
            bool isVisible = a_isVisible;
            Texture2D m_texture = a_texture;

            if (isVisible)
            {
                a_spriteBatch.Draw(m_texture, m_position,Color.White);
            }
        }


    }
}

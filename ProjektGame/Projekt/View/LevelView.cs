using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.View
{
    class LevelView
    {
        public void Draw(SpriteBatch a_spriteBatch, Vector2 m_position1, Vector2 m_position2, Texture2D m_texture)
        {

            a_spriteBatch.Draw(m_texture, m_position1, Color.White);
            a_spriteBatch.Draw(m_texture, m_position2, Color.White);

        }

        public void DrawNewLevel(SpriteBatch a_spriteBatch, Vector2 a_position, Texture2D a_texture)
        {
            a_spriteBatch.Draw(a_texture, a_position, Color.White);
        }
    }
}

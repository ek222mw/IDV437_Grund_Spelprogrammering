using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.View
{
    class HUDView
    {
        public void Draw(SpriteBatch a_spritebatch, Texture2D a_texture, Vector2 a_position)
        {
            a_spritebatch.Draw(a_texture, a_position, Color.White);
        }

        public void DrawString(SpriteBatch a_spritebatch, SpriteFont a_spritefont, int a_score)
        {
            
            a_spritebatch.DrawString(a_spritefont, "Score " + a_score, new Vector2(50, 50), Color.White);
        }
    }
}

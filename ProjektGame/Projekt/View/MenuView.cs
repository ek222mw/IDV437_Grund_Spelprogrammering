using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.View
{
    class MenuView
    {
        public void DrawScore(SpriteBatch a_spriteBatch, Texture2D a_texture, SpriteFont a_spritefont, int a_score)
        {
            a_spriteBatch.Draw(a_texture, new Vector2(0, 0), Color.White);
            a_spriteBatch.DrawString(a_spritefont, "Total Score " + a_score, new Vector2(50, 50), Color.Yellow);
        }

        public void Draw(SpriteBatch a_spriteBatch, Texture2D a_newTexture)
        {
            a_spriteBatch.Draw(a_newTexture, new Vector2(0, 0), Color.White);
        }
    }
}

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

        public void Draw(SpriteBatch a_spriteBatch, Texture2D a_newTexture)
        {
            a_spriteBatch.Draw(a_newTexture, new Vector2(0, 0), Color.White);
        }
    }
}

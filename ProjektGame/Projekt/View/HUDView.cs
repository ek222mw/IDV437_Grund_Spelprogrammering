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
    }
}

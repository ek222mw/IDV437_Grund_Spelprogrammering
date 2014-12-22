using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.View
{
    class ShipView
    {
        public void Draw(SpriteBatch a_spriteBatch, Vector2 a_position, List<Bullet> a_BulletsList, Texture2D a_shipTexture, Texture2D a_bulletTexture,
            Texture2D a_lifeTexture, Rectangle a_healthRect)
        {
           
            //ritar ut skeppet.
            a_spriteBatch.Draw(a_shipTexture, a_position, Color.White);
            a_spriteBatch.Draw(a_lifeTexture, a_healthRect, Color.White);
            // hämta position och ritar sedan ut skotten.
            foreach (Bullet b in a_BulletsList)
            {
                a_spriteBatch.Draw(a_bulletTexture, b.getPos(), Color.White);
            }

        }
    }
}

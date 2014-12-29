using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.View
{
    class ExplosionView
    {
        public void Draw(SpriteBatch a_spritebatch, List<Explosion> a_explosionList)
        {
            foreach (Explosion ex in a_explosionList)
            {
                a_spritebatch.Draw(ex.getTexture, ex.getPos,ex.getSourceRect, Color.White, 0f, ex.getOrigin, 1.0f, SpriteEffects.None, 0.0f);
            }

        }
    }
}

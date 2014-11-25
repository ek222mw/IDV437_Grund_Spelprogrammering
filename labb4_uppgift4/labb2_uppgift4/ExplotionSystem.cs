using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labb2_uppgift4
{
    class ExplotionSystem
    {
        private Vector2 position;


        private ExplotionParticle explotionParicle;

        public ExplotionSystem(Viewport viewPort, ContentManager content)
        {
            position = new Vector2(0.5f, 0.5f);

            explotionParicle = new ExplotionParticle(viewPort, position, content);
        }

        public void Draw(SpriteBatch spriteBatch, float timeElapsed)
        {

            explotionParicle.Draw(spriteBatch, timeElapsed);
        }


    }
}

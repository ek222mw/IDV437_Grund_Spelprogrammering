using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.Model
{
    class Sound
    {
        public SoundEffect m_playerShoot;
        public SoundEffect m_explosion;
        public SoundEffect m_backgroundMusic;

        public Sound()
        {
            m_playerShoot = null;
            m_explosion = null;
            m_backgroundMusic = null;

        }

        public void LoadContent(ContentManager content)
        {
            m_playerShoot = content.Load<SoundEffect>("pulse");
            m_explosion = content.Load<SoundEffect>("boom1");
            m_backgroundMusic = content.Load<SoundEffect>("bgmusic");
        }

    }
}

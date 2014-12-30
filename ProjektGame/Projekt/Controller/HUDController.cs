using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.Model
{
    class HUDController
    {
        public int m_playerScore;
        private int m_windowWidth;
        private int m_windowHeight;
        Texture2D m_playerScoreTexture;
        Texture2D m_player500ScoreReached;
        Vector2 m_scorePos, m_500ScorePos;
        public bool m_HUDShow;



        public HUDController(int a_width, int a_height)
        {
            m_playerScore = 0;
            m_windowWidth = a_width;
            m_windowHeight = a_height;
            m_playerScoreTexture = null;
            m_player500ScoreReached = null;
            m_HUDShow = true;
            m_scorePos = new Vector2(m_windowWidth / 2, 50);
            m_500ScorePos = new Vector2(m_windowWidth/3, 70);

        }

        public void LoadContent(ContentManager content)
        {
            m_playerScoreTexture = content.Load<Texture2D>("score");
            m_player500ScoreReached = content.Load<Texture2D>("500points");

           
            
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keystate = Keyboard.GetState();
        }

        public void Draw(SpriteBatch a_spritebatch)
        {
            if (m_HUDShow)
            {
                
                if (m_playerScore >= 500 && m_playerScore <= 520)
                {
                    a_spritebatch.Draw(m_playerScoreTexture, m_scorePos, Color.White);
                    a_spritebatch.Draw(m_player500ScoreReached, m_500ScorePos, Color.White);
                }

            }

        }
    }
}

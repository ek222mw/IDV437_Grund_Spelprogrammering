using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projekt.View;
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
        Texture2D m_player500ScoreTexture;
        Texture2D m_player1000ScoreTexture, m_player1500ScoreTexture, m_player2000ScoreTexture, m_player5000ScoreTexture;
        Vector2 m_scorePos, m_ReachedScorePos;
        public bool m_HUDShow;
        HUDView m_hudView = new HUDView();



        public HUDController(int a_width, int a_height)
        {
            m_playerScore = 0;
            m_windowWidth = a_width;
            m_windowHeight = a_height;
            m_playerScoreTexture = null;
            m_player500ScoreTexture = null;
            m_player1000ScoreTexture = null;
            m_player1500ScoreTexture = null;
            m_player2000ScoreTexture = null;
            m_player5000ScoreTexture = null;
            m_HUDShow = true;
            m_scorePos = new Vector2(m_windowWidth / 2, 50);
            m_ReachedScorePos = new Vector2(m_windowWidth/3, 70);

        }

        public void LoadContent(ContentManager content)
        {
            m_playerScoreTexture = content.Load<Texture2D>("score");
            m_player500ScoreTexture = content.Load<Texture2D>("500points");
            m_player1000ScoreTexture = content.Load<Texture2D>("1000points");
            m_player1500ScoreTexture = content.Load<Texture2D>("1500points");
            m_player2000ScoreTexture = content.Load<Texture2D>("2000points");
            m_player5000ScoreTexture = content.Load<Texture2D>("5000points");


           
            
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
                    m_hudView.Draw(a_spritebatch, m_playerScoreTexture, m_scorePos);
                    m_hudView.Draw(a_spritebatch, m_player500ScoreTexture, m_ReachedScorePos);
                }

                else if (m_playerScore >= 1000 && m_playerScore <= 1020)
                {
                    m_hudView.Draw(a_spritebatch, m_playerScoreTexture, m_scorePos);
                    m_hudView.Draw(a_spritebatch, m_player1000ScoreTexture, m_ReachedScorePos);
                }

                else if (m_playerScore >= 1500 && m_playerScore <= 1520)
                {
                    m_hudView.Draw(a_spritebatch, m_playerScoreTexture, m_scorePos);
                    m_hudView.Draw(a_spritebatch, m_player1500ScoreTexture, m_ReachedScorePos);
                }
                else if (m_playerScore >= 2000 && m_playerScore <= 2020)
                {
                    m_hudView.Draw(a_spritebatch, m_playerScoreTexture, m_scorePos);
                    m_hudView.Draw(a_spritebatch, m_player2000ScoreTexture, m_ReachedScorePos);
                }
                else if (m_playerScore >= 5000 && m_playerScore <= 5020)
                {
                    m_hudView.Draw(a_spritebatch, m_playerScoreTexture, m_scorePos);
                    m_hudView.Draw(a_spritebatch, m_player5000ScoreTexture, m_ReachedScorePos);
                }

            }

        }
    }
}

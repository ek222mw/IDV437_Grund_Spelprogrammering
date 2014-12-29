using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Projekt.Model;
using Projekt.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.Controller
{
    class ExplosionController
    {
        
        private int m_windowWidth, m_windowHeight;
        ExplosionSimulation m_explosionSimulation;
        List<Explosion> m_explosionList;
        ExplosionView m_explosionView;
        

        public ExplosionController(int a_width,int a_height)
        {
            m_windowWidth = a_width;
            m_windowHeight = a_height;
            m_explosionList = new List<Explosion>();
            m_explosionSimulation = new ExplosionSimulation();
            m_explosionView = new ExplosionView();

        }

        public void Update(GameTime gameTime, List<Explosion> a_explosionList)
        {

            m_explosionList = m_explosionSimulation.CreateExplosions(a_explosionList);
        }

        public void Draw(SpriteBatch a_spriteBatch)
        {
            m_explosionView.Draw(a_spriteBatch, m_explosionList);

        }





    }
}

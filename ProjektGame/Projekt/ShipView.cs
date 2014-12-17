using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Projekt
{
    class ShipView
    {
        private Texture2D m_Shiptexture, m_BulletTexture;
        private Vector2 m_position;
        private float vShipSpeed;
        
        public Rectangle m_boundingBox;
        public bool isColliding;
        Camera m_camera;
        Ship m_ship;
        private float m_scale;
        private List<Bullet> m_BulletsList;
        
        private float vx;
        private float vy;
        private  int m_windowWidth;
        private  int m_windowHeight;
        Level m_level;
        
        BulletSimulation m_bulletSimulation;
       
        public ShipView(int Width, int Height)
        {
            m_windowWidth = Width;
            m_windowHeight = Height;
            m_Shiptexture = null;
            m_BulletsList = new List<Bullet>();
            m_camera = new Camera(Width, Height);
            m_ship = new Ship();
            m_level = new Level();
           
            m_bulletSimulation = new BulletSimulation(m_BulletTexture);
            m_scale = m_camera.getScale();
            vx = m_ship.m_x * m_scale;
            vy = m_ship.m_y * m_scale;
            m_position = new Vector2(vx, vy);
            vShipSpeed = m_camera.getScale() * m_ship.m_ShipSpeed;
           

            
           
            isColliding = false;

        }

        public void LoadContent(ContentManager a_content)
        {
            m_Shiptexture = a_content.Load<Texture2D>("ship");
            m_BulletTexture = a_content.Load<Texture2D>("playerbullet");
            
        }

        public void Update(GameTime timeElapsed)
        {
            KeyboardState keyState = Keyboard.GetState();
           
            if (keyState.IsKeyDown(Keys.Space))
            {
                m_BulletsList = m_bulletSimulation.PlayerShoot(m_position,m_BulletsList, m_BulletTexture);
            }

            
            m_BulletsList = m_bulletSimulation.UpdateBullet(m_BulletsList);

            //Styrning av skeppet.
            if (keyState.IsKeyDown(Keys.W))
            {
                m_position.Y = m_position.Y - vShipSpeed;
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                m_position.X = m_position.X - vShipSpeed;
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                m_position.Y = m_position.Y + vShipSpeed;
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                m_position.X = m_position.X + vShipSpeed;
            }

            Vector2 screenposMaxShip;

            
            screenposMaxShip = m_camera.getMaxViewPosShipTexture(m_Shiptexture);

            m_position = m_ship.getCollisionWithLevelWalls(m_position, screenposMaxShip);

        }

        public void Draw(SpriteBatch a_spriteBatch)
        {
           //ritar ut skeppet.
            a_spriteBatch.Draw(m_Shiptexture, m_position, Color.White);

            // hämta position och ritar sedan ut skotten.
            foreach (Bullet b in m_BulletsList)
            {
                Vector2 pos = b.getPos();
                a_spriteBatch.Draw(m_BulletTexture, pos, Color.White);
            }
            
        }

    }

}

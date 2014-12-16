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
        private List<BulletView> m_BulletsList;
        
        private float vx;
        private float vy;
        private  int m_windowWidth;
        private  int m_windowHeight;
        Level m_level;
        Bullet m_bullet;

        public ShipView(int Width, int Height)
        {
            m_windowWidth = Width;
            m_windowHeight = Height;
            m_Shiptexture = null;
            m_BulletsList = new List<BulletView>();
            m_camera = new Camera(Width, Height);
            m_ship = new Ship();
            m_level = new Level();
            m_bullet = new Bullet();
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
                ShootBullets();
            }

            UpdatingBulletPos();

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
           
            a_spriteBatch.Draw(m_Shiptexture, m_position, Color.White);

            foreach (BulletView bw in m_BulletsList)
            {
                bw.Draw(a_spriteBatch);
            }
        }

        public void ShootBullets()
        {
            m_bullet.checkIfDelayGreaterThanZero();

            if (m_bullet.DelayTimeBullet <= 0)
            {
                BulletView newBulletView = new BulletView(m_windowWidth, m_windowHeight,m_BulletTexture);
                newBulletView.m_position = new Vector2(m_position.X + 32 - newBulletView.m_texture.Width / 2, m_position.Y + 30);

                newBulletView.m_isVisible = true;

                if (m_BulletsList.Count < 20)
                {
                    m_BulletsList.Add(newBulletView);
                }

               m_bullet.checkIfDelayEqualToZero();
            }

        }

        public void UpdatingBulletPos()
        {
            foreach (BulletView bw in m_BulletsList)
            {
                bw.m_position.Y = bw.m_position.Y - bw.m_speed;

                if (bw.m_position.Y <= 0)
                {
                    bw.m_isVisible = false;
                }
            }
            //Remove dead bullets
            for (int i = 0; i < m_BulletsList.Count; i++)
            {

                if (m_BulletsList[i].m_isVisible == false)
                {
                   
                    m_BulletsList.RemoveAt(i);
                    i--;
                }
            }
        }


    }





}

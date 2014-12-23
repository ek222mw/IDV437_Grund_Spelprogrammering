using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Projekt.View;
using Projekt.Model;

namespace Projekt.Controller
{
    class ShipController
    {
        private Texture2D m_Shiptexture, m_BulletTexture, m_LifeTexture;
        private Vector2 m_position, m_healthpos;
        private float vShipSpeed;
        ShipMovement m_shipMovement;
        public Rectangle m_boundingBox, m_RectHealth;
        public bool isColliding;
        public float health;
        Camera m_camera;
        Ship m_ship;
        private float m_scale;
        public List<Bullet> m_BulletsList;
        public Vector2 m_BulletTextureScaled;
        private Vector2 m_getBulletMiddleOfShipTexture;
        private Vector2 m_getScaledShiptexture;
        private float vx;
        private float vy;
        private  int m_windowWidth;
        private  int m_windowHeight;
        Level m_level;
        ShipView m_shipView;
        private float m_healthHeight;
       
        
        BulletSimulation m_bulletSimulation;
       
        public ShipController(int Width, int Height)
        {
            m_windowWidth = Width;
            m_windowHeight = Height;
            m_Shiptexture = null;
            m_BulletsList = new List<Bullet>();
            m_camera = new Camera(Width, Height);
            m_ship = new Ship();
            m_level = new Level();
            m_shipMovement = new ShipMovement();
            m_shipView = new ShipView();
            m_bulletSimulation = new BulletSimulation(m_BulletTextureScaled);
            m_scale = m_camera.getScale();
            vx = m_ship.m_x * m_scale;
            vy = m_ship.m_y * m_scale;
            m_position = new Vector2(vx, vy);
            health = m_ship.getLife;
            vShipSpeed = m_camera.getScale() * m_ship.m_ShipSpeed;
            
            
           

            
           
            isColliding = false;

        }

        public void LoadContent(ContentManager a_content)
        {
            m_Shiptexture = a_content.Load<Texture2D>("ship");
            m_BulletTexture = a_content.Load<Texture2D>("playerbullet");
            m_LifeTexture = a_content.Load<Texture2D>("healthbar");
            m_BulletTextureScaled = m_camera.getScaledBulletTexture(m_BulletTexture);
            
        }

        public void Update(GameTime timeElapsed)
        {
            KeyboardState keyState = Keyboard.GetState();
            
            //skalar om så att skotten alltid hamnar i centrum av skeppet oavsett upplösning.
            m_getBulletMiddleOfShipTexture = m_camera.getBulletPosMiddleOfShipTexture(m_Shiptexture);

            //skalar om skeppet till logiska koordinater.
            m_getScaledShiptexture = m_camera.getShipTextureScaled(m_Shiptexture);
            //Skapar en osynlig träff rektangel på skeppet.
            m_boundingBox = new Rectangle((int)m_position.X, (int)m_position.Y, (int)m_getScaledShiptexture.X, (int)m_getScaledShiptexture.Y);

            //hämtar ut pos till health på skeppet, skalat.Samt livet skalat och höjden på texturen skalad.
            m_healthpos = m_camera.getHealthBarPos();
            
            health = m_camera.getHealthScaled(health);
            m_healthHeight = m_camera.getHealthBarHeight(m_LifeTexture);

            m_RectHealth = new Rectangle((int)m_healthpos.X, (int)m_healthpos.Y, (int)health, (int)m_healthpos.Y);

            //Om space nedttryckt skicka ner skottlista,position o texture till det avfyrade skottet.
            if (keyState.IsKeyDown(Keys.Space))
            {
                m_BulletsList = m_bulletSimulation.PlayerShoot(m_position,m_BulletsList, m_BulletTexture, m_getBulletMiddleOfShipTexture);
            }

            //Uppdaterar skottlistan tillhörande skeppet samt kollar om skeppet blivit träffad.
            m_BulletsList = m_bulletSimulation.UpdateBullet(m_BulletsList, m_boundingBox);

            //Styrning av skepp.
            m_position = m_shipMovement.getShipMovementPos(m_position, vShipSpeed);
      
            //Få skeppet att stanna innanför ramen.
            Vector2 screenposMaxShip;
            screenposMaxShip = m_camera.getMaxViewPosShipTexture(m_Shiptexture);

            m_position = m_ship.getCollisionWithLevelWalls(m_position, screenposMaxShip);

        }

        public void Draw(SpriteBatch a_spriteBatch)
        {
           //ritar ut skeppet.
            m_shipView.Draw(a_spriteBatch, m_position, m_BulletsList, m_Shiptexture, m_BulletTexture, m_LifeTexture,m_RectHealth);
         
        }

    }

}

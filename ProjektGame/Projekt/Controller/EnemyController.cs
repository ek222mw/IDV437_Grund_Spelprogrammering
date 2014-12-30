using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Projekt.Model;
using Projekt.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.Model
{
    class EnemyController
    {
        
        Texture2D m_texture, m_bulletTexture;
        Vector2 m_position;
        public int m_speed, m_bulletDelay, m_currentDiffGrade;
        public float m_health;
        
        public List<Bullet> m_bulletList;
        private int m_windowWidth;
        private int m_windowHeight;
        EnemyView m_enemyView;
        Camera m_camera;
        Vector2 m_BulletTextureScaled;
        BulletSimulation m_bulletSimulation;
        private float m_scale;
        Enemy m_enemy;
        Vector2 m_getBulletMiddleOfShipTexture;

        public EnemyController(int a_width, int a_height)
        {
           
            m_bulletList = new List<Bullet>();
            m_windowWidth = a_width;
            m_windowHeight = a_height;
            m_bulletSimulation = new BulletSimulation(m_BulletTextureScaled);
            m_enemyView = new EnemyView();
            m_camera = new Camera(a_width, a_height);
            m_scale = m_camera.getScale();
            m_enemy = new Enemy();
            


        }

        public void LoadContent(ContentManager a_content)
        {
            m_bulletTexture = a_content.Load<Texture2D>("EnemyBullet");
            m_texture = a_content.Load<Texture2D>("enemyship");
            m_BulletTextureScaled = m_camera.getScaledBulletTexture(m_bulletTexture);
        }

        public void Update(GameTime gameTime, List<Enemy> a_enemyList)
        {
           
            m_getBulletMiddleOfShipTexture = m_camera.getBulletPosMiddleOfShipTexture(m_texture);

            foreach (Enemy e in a_enemyList)
            {
                


                m_bulletList = m_bulletSimulation.EnemyShoot(e.getEnemyPos, m_bulletList, m_bulletTexture, m_getBulletMiddleOfShipTexture);
                m_bulletList = m_bulletSimulation.UpdateEnemyBullet(m_bulletList,e.m_boundBox);
            }

            


        }
        
        public void Draw(SpriteBatch a_spriteBatch, List<Enemy> a_enemyList)
        {
            

             m_enemyView.Draw(a_spriteBatch, m_bulletList,m_bulletTexture, m_texture,m_position, a_enemyList);
            
        }


    }
}

﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace labb3.View
{
    class SplitterParticle
    {

        private Vector2 m_velocity;
        private Vector2 m_position;
        private Vector2 m_particleAcceleration;
        private float m_sizeSplitter = 0.03f;

        public SplitterParticle(Vector2 a_velocity, Camera a_camera, Vector2 a_position)
        {
           
            m_position = new Vector2(a_position.X, a_position.Y);
            m_velocity = a_velocity;
            m_particleAcceleration = new Vector2(0, 0.3f);

        }

        public void Update(float elapsedTime)
        {
            Vector2 m_NewVelocity = new Vector2();
            Vector2 m_NewPosition = new Vector2();


            m_NewVelocity.X = m_velocity.X + elapsedTime * m_particleAcceleration.X;
            m_NewVelocity.Y = m_velocity.Y + elapsedTime * m_particleAcceleration.Y;
            m_NewPosition.X = m_position.X + elapsedTime * m_velocity.X;
            m_NewPosition.Y = m_position.Y + elapsedTime * m_velocity.Y;

            m_position = m_NewPosition;

            m_velocity = m_NewVelocity;


        }




        public void Draw(SpriteBatch a_spriteBatch, Texture2D a_textureSplitter, Camera m_camera)
        {

            a_spriteBatch.Begin();
            a_spriteBatch.Draw(a_textureSplitter, m_camera.ScaleParticles(m_position.X, m_position.Y, m_sizeSplitter), Color.Red);
            a_spriteBatch.End();


        }

    }
}

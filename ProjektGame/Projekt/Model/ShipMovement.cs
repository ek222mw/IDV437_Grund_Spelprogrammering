using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt.Model
{
    class ShipMovement
    {

        public ShipMovement()
        {
        }

        public Vector2 getShipMovementPos(Vector2 a_position, float vShipSpeed)
        {
            Vector2 m_position = a_position;
            KeyboardState keyState = Keyboard.GetState();
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

            return new Vector2(m_position.X,m_position.Y);
        }
    }
}

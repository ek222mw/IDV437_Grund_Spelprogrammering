﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projekt
{
    class Ship
    {
       public float m_x = 0.5f;
       public float m_y = 0.5f;
       private Vector2 modelposShipMaxCanMove = new Vector2(1.0f, 1.0f);

       public Vector2 ShipMaxCanMove
       {
           get
           {
               return modelposShipMaxCanMove;
           }
       }
       public float m_ShipSpeed = 0.02f;

       public Vector2 getCollisionWithLevelWalls(Vector2 a_position, Vector2 a_screenposMaxShip)
       {

           //Få skeppet att stanna innanför ramen.
           if (a_position.X <= 0)
           {
               a_position.X = 0;
           }

           if (a_position.X >= a_screenposMaxShip.X)
           {
               a_position.X = a_screenposMaxShip.X;
           }

           if (a_position.Y <= 0)
           {
               a_position.Y = 0;
           }

           if (a_position.Y >= a_screenposMaxShip.Y)
           {
               a_position.Y = a_screenposMaxShip.Y;
           }
           return a_position;
       }


    }
}

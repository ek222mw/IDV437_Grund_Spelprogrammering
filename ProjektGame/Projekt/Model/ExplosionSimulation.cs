using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace Projekt.Model
{
    class ExplosionSimulation
    {

        public ExplosionSimulation()
        {
        }

        public List<Explosion> CreateExplosions(List<Explosion> a_explosionList)
        {
            for (int i = 0; i < a_explosionList.Count; i++)
            {

                if (a_explosionList[i].m_isVisible == false)
                {
                    a_explosionList.RemoveAt(i);
                    i--;
                }

            }

            return a_explosionList;

        }

    }
}

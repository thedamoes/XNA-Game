using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Engine
{
    public class Pyhsics
    {
        private CollisionDetection m_colDetector;

        public Pyhsics()
        {
            m_colDetector = new CollisionDetection();
        }

        public void notifyCollisions()
        {
            m_colDetector.notifyCollisions();
        }

        public void registerMoveableSolid(Sprite mSolid)
        {
            m_colDetector.attatchMoveing(mSolid);
        }

        public void registerFixedSolid(Sprite fSolid)
        {
            m_colDetector.attatchFixed(fSolid);
        }

        public void updateVectors()
        {

        }
    }


}

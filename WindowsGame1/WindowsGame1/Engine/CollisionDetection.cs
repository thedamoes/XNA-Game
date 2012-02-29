using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WindowsGame1.Engine
{
    class CollisionDetection
    {
        private List<Sprite> m_fixedObjects;
        private List<Sprite> m_moveingObjects;

        public CollisionDetection()
        {
            m_fixedObjects = new List<Sprite>();
            m_moveingObjects = new List<Sprite>();

        }

        public void attatchFixed(Sprite sObj)
        {
            m_fixedObjects.Add(sObj);
        }

        public void attatchMoveing(Sprite mObj)
        {
            m_moveingObjects.Add(mObj);
        }

        public void notifyCollisions()
        {
            foreach (Sprite moveing in m_moveingObjects)
            {
                Vector2 moveingPos = moveing.CenterPoint;
                float moveingHeight = moveing.height;
                float moveingWidth = moveing.width;
                foreach (Sprite fSprite in m_fixedObjects)
                {
                    if ((moveingPos.Y - moveingHeight) < (fSprite.CenterPoint.Y - fSprite.height))
                        moveing.collidedFloor(); // change to appropriate collision type later

                }
            }
        }
    }
}

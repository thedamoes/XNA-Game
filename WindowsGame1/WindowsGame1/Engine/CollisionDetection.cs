using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WindowsGame1.Engine
{
    public class CollisionDetection
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
                float moveingHeight = moveing.height/2;
                float moveingWidth = moveing.width/2;
                
                foreach (Sprite fSprite in m_fixedObjects)
                {
                    float fizedHeight = fSprite.height / 2;
                    float fixedWidth = fSprite.width / 2;

                    if (
                            ((moveingPos.Y + moveingHeight) > (fSprite.CenterPoint.Y - fizedHeight)) // check for y collisions
                            && occupiesSameXSpace(moveingPos,moveingWidth,fSprite.CenterPoint,fixedWidth))   
                             moveing.collidedFloor(moveingPos, fSprite.height);

                }
            }
        }

        public Boolean occupiesSameXSpace(Vector2 center1, float width1, Vector2 center2, float width2)
        {
            float obj1LeftEdge = center1.X - width1;
            float obj1RightEdge = center1.X + width1;

            float obj2RightEdge = center2.X + width2;
            float obj2LeftEdge = center2.X - width2;

            if ((obj1RightEdge > obj2LeftEdge) && (obj1LeftEdge < obj2RightEdge))
                return true;
            
            return false;
        }
    }
}

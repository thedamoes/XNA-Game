using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XNA_Game_UnitTests
{
    /// <summary>
    /// Summary description for ColDetectionXspaceOcupier
    /// </summary>
    [TestClass]
    public class ColDetectionXspaceOcupier
    {

        [TestMethod]
        public void objectsOccupieSameSpace()
        {
           WindowsGame1.Engine.CollisionDetection colDetect = new WindowsGame1.Engine.CollisionDetection();

           bool xSpace = colDetect.occupiesSameXSpace(new Microsoft.Xna.Framework.Vector2(10, 0), 5, new Microsoft.Xna.Framework.Vector2(17), 5);
           Assert.AreEqual(xSpace, true);
        }

        [TestMethod]
        public void objectsDontOccupieSameSpace()
        {
            WindowsGame1.Engine.CollisionDetection colDetect = new WindowsGame1.Engine.CollisionDetection();

            bool xSpace = colDetect.occupiesSameXSpace(new Microsoft.Xna.Framework.Vector2(10, 0), 5, new Microsoft.Xna.Framework.Vector2(21), 5);
            Assert.AreEqual(xSpace, false);
        }
    }
}

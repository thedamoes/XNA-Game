using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    class TerainManager :Sprite
    {
        private List<platForm> terrains = new List<platForm>();

        public TerainManager()
        {
            // initalise the map terains here

            terrains.Add(new platForm(100, 100, 1));
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch theSpriteBatch)
        {
            foreach (platForm p in terrains)
                p.Draw(theSpriteBatch);
        }

        public void loadTerainContents(ContentManager cm)
        {
            foreach (platForm p in terrains)
                p.LoadContent(cm);
        }

    }
}

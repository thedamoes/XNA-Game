using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class StaminaBar:Sprite
    {
        public int stamina = 300;

        const string STAMINA_BAR_BORDER = "HealthBar2";

        private int windowWidth =800;


        public void LoadContent(ContentManager theContentManager)
        {
            base.LoadContent(theContentManager, STAMINA_BAR_BORDER);

        } 
       
        public override void Draw(SpriteBatch theSpriteBatch)
        {
            //theSpriteBatch.Begin();

            theSpriteBatch.Draw(base.mSpriteTexture, new Rectangle(windowWidth / 2 - base.mSpriteTexture.Width / 2,
            30, base.mSpriteTexture.Width, 44), new Rectangle(0, 45, base.mSpriteTexture.Width, 44), Color.Gray);

            theSpriteBatch.Draw(base.mSpriteTexture, new Rectangle(windowWidth / 2 - base.mSpriteTexture.Width / 2,
            30, (int)(base.mSpriteTexture.Width * ((double)stamina / 300)), 44), new Rectangle(0, 45, base.mSpriteTexture.Width, 44), Color.Green);

            theSpriteBatch.Draw(base.mSpriteTexture, new Rectangle(windowWidth / 2 - base.mSpriteTexture.Width / 2,
            30, base.mSpriteTexture.Width, 44), new Rectangle(0, 0, base.mSpriteTexture.Width, 44), Color.White);


           // theSpriteBatch.End();
        }


    }
}

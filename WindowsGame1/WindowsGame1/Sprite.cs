using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame1
{
    public class Sprite
    {
        //The current position of the Sprite

        public Vector2 Position = new Vector2(0, 0);

        public int screen = 0;
        //The texture object used when drawing the sprite

        public string AssetName;


        protected Texture2D mSpriteTexture;
        

        public Rectangle Size;

        private float mScale = 0.5f;

        public Vector2 CenterPoint
        {
            get { Vector2 centP = new Vector2();
            centP.X = Position.X + (width / 2);
            centP.Y = Position.Y - (height / 2);
            return centP;
            }
        }
        public float height
        {
            get { return Size.Height; }
        }
        public float width
        {
            get { return Size.Width; }
        }

       
        

        //Load the texture for the sprite using the Content Pipeline



        //The Rectangular area from the original image that 

        //defines the Sprite. 

        Rectangle mSource;

        public Rectangle Source
        {

            get { return mSource; }

            set
            {

                mSource = value;

                Size = new Rectangle(0, 0, (int)(mSource.Width * Scale), (int)(mSource.Height * Scale));

            }

        }




        //When the scale is modified throught he property, the Size of the 

        //sprite is recalculated with the new scale applied.
        public float Scale
        {
            get { return mScale; }
            set
            {
                mScale = value;

                //Recalculate the Size of the Sprite with the new scale

                Size = new Rectangle(0, 0, (int)(Source.Width * Scale), (int)(Source.Height * Scale));
            }
        }


        //Update the Sprite and change it's position based on the passed in speed, direction and elapsed time.

        public void Update(GameTime theGameTime, Vector2 theSpeed, Vector2 theDirection)
        {

            Position += theDirection * theSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;

        }



        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {

            mSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            AssetName = theAssetName;
            Source = new Rectangle(0, 0, mSpriteTexture.Width, mSpriteTexture.Height);
            Size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));
        }

        public virtual void Draw(SpriteBatch theSpriteBatch)
        {

            theSpriteBatch.Draw(mSpriteTexture, Position, Source,
                Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);

        }


        #region collision_Detection_Virtuals
        public virtual void collidedFloor()
        {

        }
        #endregion




    }

}

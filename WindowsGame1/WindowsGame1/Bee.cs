using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace WindowsGame1
{
    class Bee : Sprite
    {
        const string BEE_ASSETNAME = "ohgodwhy";
        const int START_POSITION_X = 0;
        const int START_POSITION_Y = 450;
        const int BEE_SPEED = 260;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;



        enum State
        {
            Walking,
            Jumping,
            Ohgodwhy
        }

        State mCurrentState = State.Walking;
        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;
        KeyboardState mPreviousKeyboardState;
        Vector2 mStartingPosition = Vector2.Zero;
        List<Fireball> mFireballs = new List<Fireball>();



        ContentManager mContentManager;




        public void LoadContent(ContentManager theContentManager)
        {
            mContentManager = theContentManager;

            foreach (Fireball aFireball in mFireballs)
            {

                aFireball.LoadContent(theContentManager);

            }

            Position = new Vector2(START_POSITION_X, START_POSITION_Y);

            base.LoadContent(theContentManager, BEE_ASSETNAME);
            Source = new Rectangle(200, 0, 200, Source.Height);
        }


        public void Update(GameTime theGameTime)
        {

            KeyboardState aCurrentKeyboardState = Keyboard.GetState();

            UpdateMovement(aCurrentKeyboardState);
            UpdateJump(aCurrentKeyboardState);
            UpdateOhgodwhy(aCurrentKeyboardState);
            UpdateFireball(theGameTime, aCurrentKeyboardState);

            mPreviousKeyboardState = aCurrentKeyboardState;

            base.Update(theGameTime, mSpeed, mDirection);

        }

        private void UpdateFireball(GameTime theGameTime, KeyboardState aCurrentKeyboardState)
        {

            foreach (Fireball aFireball in mFireballs)
            {

                aFireball.Update(theGameTime);

            }



            if (aCurrentKeyboardState.IsKeyDown(Keys.RightControl) == true && mPreviousKeyboardState.IsKeyDown(Keys.RightControl) == false)
            {

                ShootFireball();

            }

        }




        private void ShootFireball()
        {

            if (mCurrentState == State.Walking || mCurrentState == State.Jumping)
            {

                bool aCreateNew = true;

                foreach (Fireball aFireball in mFireballs)
                {

                    if (aFireball.Visible == false)
                    {

                        aCreateNew = false;

                        aFireball.Fire(Position + new Vector2(Size.Width / 2, Size.Height / 2),

                            new Vector2(200, 0), new Vector2(1, 0));

                        break;

                    }

                }



                if (aCreateNew == true)
                {

                    Fireball aFireball = new Fireball();

                    aFireball.LoadContent(mContentManager);

                    aFireball.Fire(Position + new Vector2(Size.Width / 2, Size.Height / 2),

                        new Vector2(200, 200), new Vector2(1, 0));

                    mFireballs.Add(aFireball);

                }

            }

        }





        private void UpdateOhgodwhy(KeyboardState aCurrentKeyboardState)
        {

            if (aCurrentKeyboardState.IsKeyDown(Keys.RightShift) == true)
            {

                Ohgodwhy();

            }

            else
            {

                StopOhgodwhy();

            }

        }

        private void Ohgodwhy()
        {

            if (mCurrentState == State.Walking)
            {

                mSpeed = Vector2.Zero;

                mDirection = Vector2.Zero;



                Source = new Rectangle(0, 0, 200, Source.Height);

                mCurrentState = State.Ohgodwhy;

            }

        }

        private void StopOhgodwhy()
        {

            if (mCurrentState == State.Ohgodwhy)
            {

                Source = new Rectangle(200, 0, 200, Source.Height);

                mCurrentState = State.Walking;

            }

        }



        private void UpdateMovement(KeyboardState aCurrentKeyboardState)
        {

            if (mCurrentState == State.Walking)
            {

                mSpeed = Vector2.Zero;

                mDirection = Vector2.Zero;



                if (aCurrentKeyboardState.IsKeyDown(Keys.Left) == true)
                {

                    mSpeed.X = BEE_SPEED;

                    mDirection.X = MOVE_LEFT;

                }

                else if (aCurrentKeyboardState.IsKeyDown(Keys.Right) == true)
                {

                    mSpeed.X = BEE_SPEED;

                    mDirection.X = MOVE_RIGHT;

                }



               /* if (aCurrentKeyboardState.IsKeyDown(Keys.Up) == true)
                {

                    mSpeed.Y = BEE_SPEED;

                    mDirection.Y = MOVE_UP;

                }

                else if (aCurrentKeyboardState.IsKeyDown(Keys.Down) == true)
                {

                    mSpeed.Y = BEE_SPEED;

                    mDirection.Y = MOVE_DOWN;

                }*/

            }

        }

        private void UpdateJump(KeyboardState aCurrentKeyboardState)
        {

            if (mCurrentState == State.Walking)
            {

                if (aCurrentKeyboardState.IsKeyDown(Keys.Space) == true && mPreviousKeyboardState.IsKeyDown(Keys.Space) == false)
                {

                    Jump();

                }

            }

            if (mCurrentState == State.Jumping)
            {

                if (mStartingPosition.Y - Position.Y > 150)
                {

                    mDirection.Y = MOVE_DOWN;

                }



                if (Position.Y > mStartingPosition.Y)
                {

                    Position.Y = mStartingPosition.Y;

                    mCurrentState = State.Walking;

                    mDirection = Vector2.Zero;

                }


                if (aCurrentKeyboardState.IsKeyDown(Keys.Space) == true && mPreviousKeyboardState.IsKeyDown(Keys.Space) == false)
                {

                    Jump();

                }

            }

        }


        private void Jump()
        {

            if (mCurrentState != State.Jumping)
            {

                mCurrentState = State.Jumping;

                mStartingPosition = Position;

                mDirection.Y = MOVE_UP;

                mSpeed = new Vector2(BEE_SPEED, BEE_SPEED);

            }

        }


        public override void Draw(SpriteBatch theSpriteBatch)
        {

            foreach (Fireball aFireball in mFireballs)
            {

                aFireball.Draw(theSpriteBatch);

            }

            base.Draw(theSpriteBatch);

        }




    }
}

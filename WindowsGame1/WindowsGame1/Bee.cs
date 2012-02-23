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
        const string BEE_ASSETNAME = "Bee";
        const int START_POSITION_X = 125;
        const int START_POSITION_Y = 245;
        const int BEE_SPEED = 260;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;



        enum State
        {
            Walking,
            Jumping
        }

        State mCurrentState = State.Walking;
        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;
        KeyboardState mPreviousKeyboardState;
        Vector2 mStartingPosition = Vector2.Zero;



        public void LoadContent(ContentManager theContentManager)
        {

            Position = new Vector2(START_POSITION_X, START_POSITION_Y);

            base.LoadContent(theContentManager, BEE_ASSETNAME);

        }


        public void Update(GameTime theGameTime)
        {

            KeyboardState aCurrentKeyboardState = Keyboard.GetState();

            UpdateMovement(aCurrentKeyboardState);
            UpdateJump(aCurrentKeyboardState);


            mPreviousKeyboardState = aCurrentKeyboardState;

            base.Update(theGameTime, mSpeed, mDirection);

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



                if (aCurrentKeyboardState.IsKeyDown(Keys.Up) == true)
                {

                    mSpeed.Y = BEE_SPEED;

                    mDirection.Y = MOVE_UP;

                }

                else if (aCurrentKeyboardState.IsKeyDown(Keys.Down) == true)
                {

                    mSpeed.Y = BEE_SPEED;

                    mDirection.Y = MOVE_DOWN;

                }

            }

        }

        private void UpdateJump(KeyboardState aCurrentKeyboardState)
        {

            if (mCurrentState == State.Walking)
            {

                if (aCurrentKeyboardState.IsKeyDown(Keys.Space) == true /*&& mPreviousKeyboardState.IsKeyDown(Keys.Space) == false*/)
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


                if (aCurrentKeyboardState.IsKeyDown(Keys.Space) == true /*&& mPreviousKeyboardState.IsKeyDown(Keys.Space) == false*/)
                {

                    Jump();

                }

            }

        }


        private void Jump()
        {

           // if (mCurrentState != State.Jumping)
            //{

                mCurrentState = State.Jumping;

                mStartingPosition = Position;

                mDirection.Y = MOVE_UP;

                mSpeed = new Vector2(BEE_SPEED, BEE_SPEED);

            //}

        }





    }
}

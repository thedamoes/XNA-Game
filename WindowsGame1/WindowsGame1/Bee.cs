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
        int gifpos = 1;
        bool back = false;
        static int flightDuation = 300;
        public int stamina = flightDuation;

        public int getStamina
        {
            get { return stamina; }
        }

        enum State
        {
            Walking,
            Jumping,
            Ohgodwhy,
            Flying
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
            Source = new Rectangle(200, 0, 200, 200);
        }


        public void Update(GameTime theGameTime)
        {

            KeyboardState aCurrentKeyboardState = Keyboard.GetState();
           // Below:  resets position of char if it reaches the width of the screen. 
            if (Position.X >= 790)
            {
                Position.X = 0;
                screen = 1;
            }
            UpdateMovement(aCurrentKeyboardState);
            UpdateJump(aCurrentKeyboardState);
            UpdateOhgodwhy(aCurrentKeyboardState);
            UpdateFireball(theGameTime, aCurrentKeyboardState);
            UpdateFlight(aCurrentKeyboardState);
            mPreviousKeyboardState = aCurrentKeyboardState;

            base.Update(theGameTime, mSpeed, mDirection);

        }

        private void UpdateFlight(KeyboardState aCurrentKeyboardState)
        {

            if (aCurrentKeyboardState.IsKeyDown(Keys.F) == true)
            {
                if (stamina > 0)
                {
                    stamina--;
                    Flight(aCurrentKeyboardState);
                }
                else
                {
                    if (stamina < flightDuation)
                    {
                        stamina++;
                    }

                    StopFlight();
                }

            }

            else if (aCurrentKeyboardState.IsKeyDown(Keys.F) == false)
            {
                if (stamina < flightDuation)
                {
                    stamina++;
                }
                StopFlight();
            }


        }



        private void Flight(KeyboardState aCurrentKeyboardState)
        {

            if (mCurrentState == State.Walking)
            {
                mSpeed = Vector2.Zero;

                mDirection = Vector2.Zero;

                mCurrentState = State.Flying;
                 
               
            }

            if(mCurrentState == State.Flying)
            {


                mSpeed = Vector2.Zero;

                mDirection = Vector2.Zero;


                FlightAnimation(aCurrentKeyboardState);

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

        private void StopFlight()
        {
            if (mCurrentState == State.Flying)
            {

                if (Position.Y > 450)
                {

                    Position.Y = 450;

                    mCurrentState = State.Walking;

                    mDirection = Vector2.Zero;

                }


                Source = new Rectangle(200, 0, 200, 200);

                mCurrentState = State.Walking;

            }

            if (mCurrentState == State.Walking)
            {
                if (Position.Y < 450)
                {
                    mSpeed.Y = BEE_SPEED;

                    mDirection.Y = MOVE_DOWN;

                }
            }

        }



        private void FlightAnimation(KeyboardState aCurrentKeyboardState)
        {
            if (gifpos <= 3)
            {
                if (gifpos <= 1)
                {
                    if (aCurrentKeyboardState.IsKeyDown(Keys.Right) == true)
                    {
                        Source = new Rectangle(0, 600, 200, 200);
                    }
                    else if (aCurrentKeyboardState.IsKeyDown(Keys.Left) == true)
                    { 
                        Source = new Rectangle(0, 400, 200, 200);
                    }
                    else
                    {
                        Source = new Rectangle(0, 200, 200, 200);
                    }
                    if (back)
                    {
                        if (gifpos > 0)
                        {
                            gifpos--;
                        }
                        else
                        {
                            gifpos++;
                            back = false;
                        }

                    }
                    else
                    {
                        gifpos++;
                        back = false;
                    }

                }
                if (gifpos <= 2 && gifpos >= 2)
                {
                    if (aCurrentKeyboardState.IsKeyDown(Keys.Right) == true)
                    {
                        Source = new Rectangle(200, 600, 200, 200);
                    }
                    else if (aCurrentKeyboardState.IsKeyDown(Keys.Left) == true)
                    {
                        Source = new Rectangle(200, 400, 200, 200);
                    }
                    else
                    {
                        Source = new Rectangle(200, 200, 200, 200);
                    }
                    if (back)
                    {
                        gifpos--;
                    }
                    else
                    {
                        gifpos++;
                    }
                }
                if (gifpos <= 3 && gifpos >= 3)
                {
                    if (aCurrentKeyboardState.IsKeyDown(Keys.Right) == true)
                    {
                        Source = new Rectangle(400, 600, 200, 200);
                    }
                    else if (aCurrentKeyboardState.IsKeyDown(Keys.Left) == true)
                    {
                        Source = new Rectangle(400, 400, 200, 200);
                    }
                    else
                    {
                        Source = new Rectangle(400, 200, 200, 200);
                    }
                    if (!back)
                    {
                        if (gifpos < 3)
                        {
                            gifpos++;
                        }
                        else
                        {
                            gifpos--;
                            back = true;
                        }

                    }
                    else
                    {
                        gifpos--;
                    }

                }

            }
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

            if (mCurrentState == State.Walking || mCurrentState == State.Jumping || mCurrentState == State.Flying)
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

            if (mCurrentState == State.Walking || mCurrentState == State.Flying)
            {

                mSpeed = Vector2.Zero;

                mDirection = Vector2.Zero;



                Source = new Rectangle(0, 0, 200, 200);

                mCurrentState = State.Ohgodwhy;

            }

        }

        private void StopOhgodwhy()
        {

            if (mCurrentState == State.Ohgodwhy)
            {

                Source = new Rectangle(200, 0, 200, 200);

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

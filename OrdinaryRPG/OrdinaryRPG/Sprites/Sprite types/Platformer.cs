using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XnaTest3
{
    public class Platformer : Sprite
    {
        private bool onGround = false;
        public int JumpPower = 60;
        public int Gravity = 10;
        //RIGHT LEFT
        float acceleration = 0.7f;
        float deceleration = 1.2f;

        float maxspeed = 12;
        float speed = 0;
        bool goRight = true;


        public Platformer(ContentManager content)
            : base(content)
        {
            base.Speed *= 5;

        }
        public override void Update(GameTime gt)
        {
            Fall(gt);
            Jump(gt);
            MoveXAxis(gt);

            //////////
            if (Position.X < -Size.X * ScaleFactor.X - 1)
                SetPosition(new Vector2(Game1.graphics.PreferredBackBufferWidth, Position.Y));
            else if (Position.X > Game1.graphics.PreferredBackBufferWidth + 1)
                SetPosition(new Vector2(-Size.X * ScaleFactor.X, Position.Y));
            /////////

            base.Update(gt);
        }

        private void MoveXAxis(GameTime gt)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                speed = 0;
                SetVelocityX(-speed);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                SpriteEffect = SpriteEffects.FlipHorizontally;
                goRight = true;
                if (speed < maxspeed)
                    speed += acceleration * gt.ElapsedGameTime.Milliseconds / 10;
                SetVelocityX(speed);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                SpriteEffect = SpriteEffects.None;
                goRight = false;
                if (speed < maxspeed)
                    speed += acceleration * gt.ElapsedGameTime.Milliseconds / 10;
                SetVelocityX(-speed);
            }
            else
            {
                if (speed - deceleration * gt.ElapsedGameTime.Milliseconds / 10 >= 0)
                    speed -= deceleration * gt.ElapsedGameTime.Milliseconds / 10;
                else
                    speed = 0;
                if (goRight)
                    SetVelocityX(speed);
                else
                    SetVelocityX(-speed);
            }

        }
        private void Jump(GameTime gt)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && onGround)
            {
                AddVelocityY(-JumpPower*gt.ElapsedGameTime.Milliseconds/50);
            }
        }
        private void Fall(GameTime gt)
        {
            if (Position.Y + Size.Y * ScaleFactor.Y + Velocity.Y < Game1.graphics.PreferredBackBufferHeight) //for sprite don't fall out of screen
            {
                AddVelocityY(Gravity*gt.ElapsedGameTime.Milliseconds/100);
                onGround = false;
            }
            else if (Position.Y + Size.Y * ScaleFactor.Y == Game1.graphics.PreferredBackBufferHeight)
            {
                SetVelocityY(0);
                onGround = true;
            }
            else if (Position.Y + Size.Y * ScaleFactor.Y > Game1.graphics.PreferredBackBufferHeight)
            {
                SetVelocity(new Vector2(0));
                float yOffset = Game1.graphics.PreferredBackBufferHeight - Size.Y * ScaleFactor.Y;
                SetPosition(new Vector2(Position.X, yOffset));
                onGround = true;
            }
        }
    }
}

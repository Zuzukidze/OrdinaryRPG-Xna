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

namespace OridnaryRPG.Sprites.Sprite_types
{
    class Player : Sprite
    {
        public int direction;
        private int maxspeed;
        public Player(ContentManager content) : base(content)
        {
            direction = 0;
            maxspeed = 5;
        }
        public override void Update(GameTime time)
        {
            SetVelocity(new Vector2(0));
            int s = Speed * (int)time.ElapsedGameTime.Milliseconds / 60;
            bool isMovedX = false;
            bool isMovedY = false;
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                        SetVelocityY(-s);
                    isMovedY = !isMovedY;
                    direction = 2;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    SetVelocityY(s);
                    isMovedY = !isMovedY;
                    direction = 0;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                        SetVelocityX(-s);
                    isMovedX = !isMovedX;
                    direction = 1;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                        SetVelocityX(s);
                    isMovedX = !isMovedX;
                    direction = 3;
                }
            if (isMovedX || isMovedY)
            {
                //выствляем анимацию
                Animation = true;
                FrameCurrent.Y = direction;
            }
            else
            {
                //убираем анимацию и выставляем базовый кадр направления
                Animation = false;
                FrameCurrent.X = direction;
                FrameCurrent.Y = 4;
                //тормозим
                SetVelocity(new Vector2(0));
            }
            //коллизии
            if (isCollide((int)Velocity.X, 0))
                SetVelocityX(0);
            if (isCollide(0, (int)Velocity.Y))
                SetVelocityY(0);
            
            

            
                base.Update(time);
        }
        /// <summary>
        /// проверяет, касается ли игрок блоков
        /// </summary>
        /// <param name="xOffset">смещение по X</param>
        /// <param name="yOffset">смещение по Y</param>
        /// <returns></returns>
        private bool isCollide(int xOffset,int yOffset)
        {
            Rectangle rect = getRect();
            rect.X += xOffset;
            rect.Y += yOffset;
            if (rect.X < 0 || rect.Y < 0 || rect.X + rect.Width > Game1.ScreenSize.X || rect.Y + rect.Height > Game1.ScreenSize.Y)
                return true;
            int x = rect.X / 64;
            int y = rect.Y / 64;
            if (Game1.Map[x, y] != null)
            {
                if (rect.Intersects(Game1.Map[x, y].getRect()))
                {
                    Game1.Map[x, y].onIntersect();
                    if (Game1.Map[x, y].isSolid)
                        return true;
                }
            }
            if (Game1.Map[x + 1, y] != null)
            {
                if (rect.Intersects(Game1.Map[x + 1, y].getRect()))
                {
                    Game1.Map[x+1, y].onIntersect();
                    if (Game1.Map[x+1, y].isSolid)
                        return true;
                }
            }
            if (Game1.Map[x, y + 1] != null)
            {
                if (rect.Intersects(Game1.Map[x, y + 1].getRect()))
                {
                    Game1.Map[x, y+1].onIntersect();
                    if (Game1.Map[x, y+1].isSolid)
                        return true;
                }
            }
            if (Game1.Map[x + 1, y + 1] != null)
            {
                if (rect.Intersects(Game1.Map[x + 1, y + 1].getRect()))
                {
                    Game1.Map[x+1, y+1].onIntersect();
                    if (Game1.Map[x+1, y+1].isSolid)
                        return true;
                }
            }
            return false;
        }

    }
}

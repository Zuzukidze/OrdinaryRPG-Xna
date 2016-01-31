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
    public class Sprite
    {
        public bool Visible = false; //видим ли мы объект
        public Vector2 Position { get; private set; } //координаты от верхнего левого угла, если использовать SetCenter, то координаты середины
        public Vector2 Velocity { get; private set; } //как будет изменяться позиция спрайта каждый кадр, по умолчанию равна (0,0)
        public Vector2 Size; //размеры объекта
        private Texture2D Picture; //картинка, графически представляющая объект
        protected SpriteEffects SpriteEffect; //эффекты спрайта
        public Color Color = Color.White; //цвет, которым рисуется объект
        public Vector2 ScaleFactor {get;private set;} //коэффицент сжатия-растяжения
        public ContentManager Content; //для упрощения, эквивалент менеджера в Game
        public Vector2 FrameCount = Vector2.One; //количество кадров, картинкапредставляется в виде матрицы.
        public Vector2 FrameCurrent = Vector2.Zero; //текущий кадр, на пересечении строкии столбца.
        public bool Animation = false; //анимировать ли картинку
        public int FramesPerSecond; //кол-во кадров в секунду
        private double TimeFromLastFrame; //время с предыдущего кадра анимации
        private double TimeToNextFrame; //время до следующего кадра анимации

        public bool isRepeat = true;
        private float Angle = 0; //угол
        public Vector2 Origin = Vector2.Zero;
        //public const float G = 9,8;

        public int Speed = 12;

        public Sprite(ContentManager content)
        {
            Content = content;
        }

        public void LoadTexture(string textureName)
        {
            LoadTexture(textureName, Vector2.Zero);
        }
        public void LoadTexture(string textureName, Vector2 position)
        {
            LoadTexture(textureName, position, new Vector2(64, 64));
        }
        public void LoadTexture(string textureName, Vector2 position, Vector2 size)
        {
            LoadTexture(textureName, position, size, Vector2.One);
        }
        public void LoadTexture(string textureName, Vector2 position, Vector2 size,
            Vector2 frameCount)
        {
            LoadTexture(textureName, position, size, frameCount, 2);
        }
        public void LoadTexture(string textureName, Vector2 position, Vector2 size,
            Vector2 frameCount, int fps)
        {
            Picture = Content.Load<Texture2D>("Textures\\" + textureName);

            Position = position;
            Size = size;
            FrameCount = frameCount;
            int t = 1000 / fps;
            FramesPerSecond = fps;
            TimeFromLastFrame = 0;
            TimeToNextFrame = t;
            Animation = false;
            Visible = true;
            Velocity = Vector2.Zero;
            ScaleFactor = Vector2.One;
        }
        //UPDATE
        public virtual void Update(GameTime time)
        {
            Move(Velocity);
        }
        //DRAW
        public void Draw(SpriteBatch spriteBatch, GameTime time)
        {
            if (Visible)
            {
                int frameSizeX = (int)(Picture.Width / FrameCount.X);
                int frameSizeY = (int)(Picture.Height / FrameCount.Y);
                int frameX = (int)(FrameCurrent.X * frameSizeX);
                int frameY = (int)(FrameCurrent.Y * frameSizeY);
                Rectangle rectangle = new Rectangle(frameX, frameY, frameSizeX,
               frameSizeY);
                spriteBatch.Draw(Picture, Position, rectangle, Color, -Angle, Origin,
               ScaleFactor, SpriteEffect, 0);
                /*spriteBatch.Draw(Picture, new Vector2(getRect().X,getRect().Y), rectangle, Color.Black, -Angle, new Vector2(0),
               ScaleFactor, SpriteEffect, 0);*/
                
                
                if (Animation)
                {
                    TimeFromLastFrame += time.ElapsedGameTime.TotalMilliseconds;
                    if (TimeFromLastFrame >= TimeToNextFrame)
                    {
                        FrameCurrent.X++;
                        TimeFromLastFrame = 0;
                    }
                    if (FrameCurrent.X > FrameCount.X - 1)
                    {
                        if (isRepeat)
                            FrameCurrent.X = 0;
                        else
                            FrameCurrent.X = FrameCount.X - 1;
                    }
                }
            }
        }
        //SCALE
        public void Scale(Vector2 size)
        {
            ScaleFactor = size / Size;
        }
        public void ScaleX(Vector2 scale)
        {
            ScaleFactor *= scale;
        }
        //MOVE
        public void Move(Vector2 XY)
        {
            SetPosition(Position + XY);
        }
        public void MoveX(float X)
        {
            SetPosition(Position + new Vector2(X, 0));
        }
        public void MoveY(float Y)
        {
            SetPosition(Position + new Vector2(0, Y));
        }
        public void SetPosition(Vector2 XY)
        {
            Position = XY;
        }
        public void SetPositionX(float x)
        {
            Position = new Vector2(x,Position.Y);
        }
        public void SetPositionY(float y)
        {
            Position = new Vector2(Position.X,y);
        }
        public void SetVelocity(Vector2 velocity)
        {
            Velocity = velocity;
        }
        public void SetVelocityX(float x)
        {
            Velocity = new Vector2(x, Velocity.Y);
        }
        public void SetVelocityY(float y)
        {
            Velocity = new Vector2(Velocity.X, y);
        }
        public void AddVelocity(Vector2 velocity)
        {
            SetVelocity(velocity + Velocity);
        }
        public void AddVelocityX(float x)
        {
            AddVelocity(new Vector2(x, Velocity.Y));
        }
        public void AddVelocityY(float y)
        {
            AddVelocity(new Vector2(Velocity.X, y));
        }
        public void WASD()
        {
            float s = Speed / 60;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                MoveY(-s);
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                MoveX(-s);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                MoveY(s);
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                MoveX(s);
        }
        //ROTATE
        public void Rotate(float angle)
        {
            Angle = -angle;
        }
        public static float AngleToPosition(Vector2 startPosition, Vector2 position)
        {
            Vector2 dir = startPosition - position;
            return (float)(Math.Atan2(dir.X, dir.Y));
        }
        public static float AngleToMouse(Vector2 startPosition)
        {
            Vector2 dir = startPosition - new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            return -(float)(Math.Atan2(dir.X, dir.Y));
        }
        public void RotateToPosition(Vector2 position)
        {
            Vector2 dir = Position - position;
            Angle = (float)(Math.Atan2(dir.X, dir.Y));
        }
        public void RotateToMouse()
        {
            Vector2 dir = Position - new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            Angle = (float)(Math.Atan2(dir.X, dir.Y));
        }
        //ORIGIN
        public void SetOrigrnToCenter()
        {
            Origin = new Vector2(Size.X / 2 / FrameCount.X, Size.Y / 2 / FrameCount.Y);
        }
        public Rectangle getRect()
        {
            Rectangle rect = new Rectangle((int)Position.X, (int)Position.Y, (int)(Size.X * ScaleFactor.X), (int)(Size.Y * ScaleFactor.Y));
            rect.X -= (int)Origin.X * (int)ScaleFactor.X;
            rect.Y -= (int)Origin.Y * (int)ScaleFactor.Y;
            rect.Width -= 4;
            rect.Height -= 4;
            return rect;
        }
    }
}


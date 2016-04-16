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

namespace OridnaryRPG
{
    class Fire : Particle
    {
        public Vector2 startPos;
        private Random R;
        public Fire(Vector2 position, Random r, ContentManager content, GameTime gameTime, int ttl = 4500) : base(new Vector2(1,0),position,new Vector2(16),"smoke",new Vector2(8,1),content,false,ttl)
        {
            startPos = position;
            R = r;
            color = Color.Black;
            Tags = new string[1] { "smoke" };
            //ParticleSystem.AddParticle(this);
        }
        public override void Update(ref Particle[] particles, GameTime gametime)
        {
            /*if (color == Color.White)
                color = Color.Black;*/

            double x = Position.X - startPos.X;
            double y = Math.Sin(x / 30) * 30;
            //double x = R.Next(-1,2)*Math.Sin(y/R.Next(30,61))*R.Next(1,41);
            SetPosition(new Vector2(Position.X, (float)y + startPos.Y));
            SetPosition(new Vector2((float)x + startPos.X, Position.Y));
        }
    }
}

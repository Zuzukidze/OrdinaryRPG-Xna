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
    class Bullet : Particle
    {
        Random r = new Random();
        public Bullet(Vector2 start, Vector2 target, ContentManager content, GameTime gameTime) : base(Vector2.Zero,start,new Vector2(4,64),"Bullet",content)
        {
            Vector2 dir = start - target;
            dir.Normalize();
            dir *= new Vector2(64, 64);
            Velocity = -dir;
            RotateToMouse();
            TTL = 200;
            Tags = new string[1] { "bullet" };
            //ParticleSystem.AddParticle(this);
        }
        public override void Update(ref Particle[] particles, GameTime gametime)
        {
            Vector2 startcol = Position;
            for (float i = 0; i < 32; i += 1)
            {
                startcol += Velocity / 32;


                for (int j = 0; j < particles.Length; j++)
                {
                    Particle p = particles[j];
                    if (p.hasTag("smoke"))
                    {
                        if (startcol.X > p.Position.X && startcol.Y > p.Position.Y && startcol.X < p.Position.X + p.Size.X && startcol.Y < p.Position.Y + p.Size.Y)
                        {
                            p.color = Color.Red;
                        }
                    }
                }
            }
        }
    }
}

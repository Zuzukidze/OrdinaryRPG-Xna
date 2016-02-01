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
    class Bullet
    {
        public int TTL = 200; //time to life
        Random r = new Random();
        public Bullet(Vector2 start, Vector2 target, ContentManager content, GameTime gameTime)
        {
            Vector2 dir = start - target;
            dir.Normalize();
            dir *= new Vector2(64, 64);
            ParticleSystem.CreateParticle(start, -dir, new Vector2(4, 64), Vector2.One, "Bullet", content, UpdateBullet, TTL, Particle.AngleToMouse(start), "bullet");
        }
        public void UpdateBullet(ref Particle particle, ref List<Particle> particles)
        {
            Vector2 startcol = particle.Position;
            for (float i = 0; i < 32; i += 1)
            {
                startcol += particle.Velocity / 32;


                for (int j = 0; j < particles.Count; j++)
                {
                    Particle p = particles[j];
                    if (p.Tags.Contains("smoke"))
                    {
                        if (startcol.X > p.Position.X && startcol.Y > p.Position.Y && startcol.X < p.Position.X + p.Size.X && startcol.Y < p.Position.Y + p.Size.Y)
                        {
                            p.Color = Color.Red;
                        }
                    }
                }
            }
        }
    }
}

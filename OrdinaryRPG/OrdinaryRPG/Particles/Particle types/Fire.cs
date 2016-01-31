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
    class Fire
    {
        public Vector2 startPos;
        private Random R;
        public Fire(Vector2 position, Random r, ContentManager content, GameTime gameTime, int ttl = 4500)
        {
            startPos = position;
            R = r;
            ParticleSystem.CreateParticle(position, new Vector2(1, 0), new Vector2(16, 16), new Vector2(8, 1), "smoke", content, UpdateSmoke, ttl, 0, "smoke");
        }
        public void UpdateSmoke(ref Particle particle, ref List<Particle> particles)
        {
            if (particle.Color == Color.White)
                particle.Color = Color.Black;

            double x = particle.Position.X - startPos.X;
            double y = Math.Sin(x / 30) * 30;
            //double x = R.Next(-1,2)*Math.Sin(y/R.Next(30,61))*R.Next(1,41);
            particle.SetPosition(new Vector2(particle.Position.X, (float)y + startPos.Y));
            particle.SetPosition(new Vector2((float)x + startPos.X, particle.Position.Y));
        }
    }
}

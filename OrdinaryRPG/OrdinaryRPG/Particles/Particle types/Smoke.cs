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
    class Smoke
    {
        public int TTL = 4000; //time to life
        public Smoke(Vector2 position, Random r, ContentManager content, GameTime gameTime)
        {
            ParticleSystem.CreateParticle(position, new Vector2((float)r.NextDouble() - (float)r.NextDouble(), (float)r.NextDouble() - (float)r.NextDouble()), new Vector2(16, 16), new Vector2(8, 1), "smoke", content, UpdateSmoke, TTL, 0, "smoke");
        }
        public void UpdateSmoke(ref Particle particle, ref List<Particle> particles)
        {
            if (particle.Color == Color.White)
                particle.Color = Color.Black;
        }
    }
}

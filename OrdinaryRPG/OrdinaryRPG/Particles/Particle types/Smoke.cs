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
    class Smoke : Particle
    {
        public Smoke(Vector2 position, Random r, ContentManager content)
            : base(new Vector2((float)r.NextDouble() - (float)r.NextDouble(), (float)r.NextDouble() - (float)r.NextDouble()),position, new Vector2(16),"smoke",new Vector2(8,1),content,false)
        {
            TTL = 4000;
            Tags = new string[1]{"smoke"};
            color = Color.Black;
            Animation = true;
            ParticleSystem.AddParticle(this);
        }
        public override void Update(ref Particle[] particles, GameTime gametime)
        {
            /*if (this.color == Color.White)
                color = Color.Black;*/
        }
    }
}

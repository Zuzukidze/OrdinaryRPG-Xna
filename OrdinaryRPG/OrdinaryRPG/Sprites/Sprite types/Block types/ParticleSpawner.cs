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
using OridnaryRPG;
using OrdinaryRPG.Particles;

namespace OrdinaryRPG.Sprites.Sprite_types.Block_types
{
    sealed class SmokeSpawner : Block
    {
        Random r;
        public SmokeSpawner(Random r,ContentManager content): base(content)
        {
            isSolid = false;
            this.r = r;
        }
        public override void Update(GameTime time)
        {
            ParticleSystem.AddParticle(new ParticleBasic(Position + new Vector2(getRect().Width/2,getRect().Height/2),new Vector2((float)r.NextDouble() - (float)r.NextDouble(), (float)r.NextDouble() - (float)r.NextDouble()),"smoke",Content,4000));
            base.Update(time);
        }
    }
}

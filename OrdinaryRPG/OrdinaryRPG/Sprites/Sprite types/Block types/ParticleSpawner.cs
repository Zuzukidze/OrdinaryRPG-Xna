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

namespace OrdinaryRPG.Sprites.Sprite_types.Block_types
{
    {
        Random r;
        {
            isSolid = false;
            this.r = r;
        }
        public override void Update(GameTime time)
        {
            ParticleSystem.AddParticle(new Smoke(Position + new Vector2(getRect().Width/2,getRect().Height/2),r,Content));
            base.Update(time);
        }
    }
}

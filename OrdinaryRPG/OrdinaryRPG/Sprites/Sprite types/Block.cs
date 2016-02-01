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

namespace OrdinaryRPG.Sprites.Sprite_types
{
    public class Block : Sprite
    {
        public bool isSolid { get; protected set; }

        public Block(ContentManager content) : base(content)
        {

        }
        public virtual void onActivate() {}
        public virtual void onIntersect() {}
        
    }
}

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

namespace OrdinaryRPG.Sprites.Sprite_types.Block_types
{
    sealed class Button : Block
    {
        Vector2 TargetCord;
        public Button(ContentManager content) : base(content)
        {
            this.isSolid = false;
        }

        public override void onActivate()
        {
            FrameCurrent.X = 1;
        }
        public override void onIntersect()
        {
            onActivate();
        }
        public override void Update(GameTime time)
        {
            FrameCurrent.X = 0;
            base.Update(time);
        }
    }
}

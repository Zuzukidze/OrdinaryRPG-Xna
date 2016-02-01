﻿using System;
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
    class Brick : Block
    {
        public Brick(ContentManager content) : base(content)
        {
            this.isSolid = true;
        }
    }
}
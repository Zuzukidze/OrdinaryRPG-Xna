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

namespace OridnaryRPG
{
    class Magazine : Sprite
    {
        private int BulletsCount;
        public Magazine(ContentManager content, int bulletsCount)
            : base(content)
        {
            BulletsCount = bulletsCount;
        }
    }
}

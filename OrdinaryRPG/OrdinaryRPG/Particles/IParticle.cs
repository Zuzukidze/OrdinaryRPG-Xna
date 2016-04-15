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

namespace OrdinaryRPG.Particles
{
    interface IParticle
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Size; //texture size

        private Texture2D texture;
        private ContentManager content;
        public bool isActive;

        public short TTL; // time to life
        public short TOL; // time of life

        public void Update(GameTime gametime);
        public void Draw(GameTime gametime);

    }
}

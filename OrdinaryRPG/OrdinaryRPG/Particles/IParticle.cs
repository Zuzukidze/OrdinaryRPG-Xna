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
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Size { get; set; } //texture size

        Texture2D texture { get; set; }
        bool isActive { get; set; }

        short TTL { get; set; } // time to life
        short TOL { get; set; } // time of life

        void Update(ref IParticle[] particles, GameTime gametime);
        void Draw(SpriteBatch spritebatch,GameTime gametime);

    }
    sealed class ParticleHelper
    {
        public static void Move(IParticle particle, Vector2 offset)
        {
            particle.Position += offset;
        }
        public static void MoveX(IParticle particle, float offsetX)
        {
            particle.Position += new Vector2(offsetX,0);
        }
        public static void MoveY(IParticle particle, float offsetY)
        {
            particle.Position += new Vector2(0,offsetY);
        }

    }
}

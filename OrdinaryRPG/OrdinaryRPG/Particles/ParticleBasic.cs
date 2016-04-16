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
namespace OrdinaryRPG.Particles
{
    struct ParticleBasic : IParticle
    {
        private Vector2 position;
        private Vector2 velocity;

        private static Texture2D texture;
        private bool isactive;

        private short ttl; // time to life
        private short tol; // time of life

        public ParticleBasic(Vector2 position, Vector2 velocity, string texturename, ContentManager content, short timetolife = 3000)
        {
            this.position = position;
            this.velocity = velocity;
            if (texture == null)
                texture = content.Load<Texture2D>("Textures\\" + texturename);
            ttl = timetolife;
            tol = 0;
            isactive = true;
        }
        public void Update(ref IParticle[] particles, GameTime gametime)
        {
            position += velocity;
        }

        public void Draw(SpriteBatch spritebatch, GameTime gametime)
        {
            spritebatch.Draw(texture, position, Color.White);
        }

        Vector2 IParticle.Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        Vector2 IParticle.Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }

        Texture2D IParticle.texture
        {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
            }
        }
        bool IParticle.isActive
        {
            get
            {
                return isactive;
            }
            set
            {
                isactive = value;
            }
        }

        short IParticle.TTL
        {
            get
            {
                return ttl;
            }
            set
            {
                ttl = value;
            }
        }
        short IParticle.TOL
        {
            get
            {
                return tol;
            }
            set
            {
                tol = value;
            }
        }

    }
}

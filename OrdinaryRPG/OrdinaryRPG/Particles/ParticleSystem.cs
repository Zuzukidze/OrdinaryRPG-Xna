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
    class ParticleSystem : DrawableGameComponent
    {
        public static Particle[] Particles = new Particle[Game1.MAX_PARTICLES_COUNT];
        SpriteBatch sBatch;
        Random r = new Random();
        //basic particle
        public static void CreateParticle(Vector2 position, Vector2 velocity, Vector2 size,
            string textureName, ContentManager content, int TTL = 3000, float angle = 0, string[] tags = null)
        {
            //create particle, thanks cap
            Particle p = new Particle(velocity, position, size, textureName, Vector2.One, content);
            p.isRepeating = false;
            p.TTL = TTL;
            p.SetOrigrnToCenter();
            p.Rotate(angle);
            p.Tags = tags;
            //add to list of particles, thanks again
            AddParticle(p);
        }
        //animated particle
        public static void CreateParticle(Vector2 position, Vector2 velocity, Vector2 size, Vector2 frameCount,
            string textureName, ContentManager content, int TTL = 3000, float angle = 0, string[] tags = null)
        {
            //create particle, thanks cap
            Particle p = new Particle(velocity, position, size, textureName, frameCount, content);
            p.isRepeating = false;
            p.TTL = TTL;
            p.SetOrigrnToCenter();
            p.Rotate(angle);
            p.Tags = tags;
            //add to list of particles, thanks again
            AddParticle(p);
        }



        public ParticleSystem(Game game)
            : base(game)
        {
        }
        protected override void LoadContent()
        {
            sBatch = new SpriteBatch(GraphicsDevice);
        }
        public override void Update(GameTime gameTime)
        {
            List<Particle> ToDelete = new List<Particle>();
            for (int i = 0; i < Particles.Length; i++)
            {
                Particle p = Particles[i];
                if (p != null && p.isActive)
                {
                    //Move particle
                    p.Move(p.Velocity);
                    //add time of life of particle
                    p.TOL += gameTime.ElapsedGameTime.Milliseconds;
                    //update particle
                    p.Update(ref Particles, gameTime);
                    //if time to die - kill particle
                    if (p.TOL >= p.TTL)
                    {
                        p.isActive = false;
                    }
                }
            }

        }
        public override void Draw(GameTime gameTime)
        {
            sBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone); //for pixels were pixels
            for (int i = 0; i < Particles.Length; i++)
            {
                Particle p = Particles[i];
                if (p != null && p.isActive)
                    p.Draw(sBatch, gameTime);
            }
            sBatch.End();
        }

        public static void AddParticle(Particle particle)
        {
            for (int i = 0; i < Particles.Length; i++)
            {
                Particle p = Particles[i];
                if (p == null || !p.isActive)
                {
                    Particles[i] = particle;
                    return;
                }
            }
        }
        public static int CountOfActiveParticles()
        {
            int count = 0;
            for (int i = 0; i < Particles.Length; i++)
            {
                Particle p = Particles[i];
                if (p != null && p.isActive)
                    count++;
            }
            return count;
        }
    }
}

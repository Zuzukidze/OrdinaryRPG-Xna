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
using OrdinaryRPG.Particles;

namespace OridnaryRPG
{
    class ParticleSystem : DrawableGameComponent
    {
        public static IParticle[] Particles = new IParticle[Game1.MAX_PARTICLES_COUNT];
        SpriteBatch sBatch;
        Random r = new Random();

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
            for (int i = 0; i < Particles.Length; i++)
            {
                IParticle p = Particles[i];
                if (p != null && p.isActive)
                {
                    //add time of life of particle
                    p.TOL += (short)gameTime.ElapsedGameTime.Milliseconds;
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
                IParticle p = Particles[i];
                if (p != null && p.isActive)
                    p.Draw(sBatch, gameTime);
            }
            sBatch.End();
        }

        public static void AddParticle(IParticle particle)
        {
            for (int i = 0; i < Particles.Length; i++)
            {
                IParticle p = Particles[i];
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
                IParticle p = Particles[i];
                if (p != null && p.isActive)
                    count++;
            }
            return count;
        }
    }
}

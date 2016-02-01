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
        public static List<Particle> Particles = new List<Particle>(); //List of all particles
        SpriteBatch sBatch;
        Random r = new Random();

        public static void CreateParticle(Vector2 position, Vector2 velocity, Vector2 size,
            string textureName, ContentManager content, int TTL = 3000, float angle = 0, string tags = "")
        {
            //create particle, thanks cap
            Particle p = new Particle(velocity, position, size, textureName, Vector2.One, content);
            p.isRepeat = false;
            p.TTL = TTL;
            p.SetOrigrnToCenter();
            p.Rotate(angle);
            p.Tags = tags;
            //add to list of particles, thanks again
            Particles.Add(p);
        }
        public static void CreateParticle(Vector2 position, Vector2 velocity, Vector2 size, Vector2 frameCount,
            string textureName, ContentManager content, int TTL = 3000, float angle = 0, string tags = "")
        {
            //create particle, thanks cap
            Particle p = new Particle(velocity, position, size, textureName, frameCount, content);
            p.isRepeat = false;
            p.TTL = TTL;
            p.SetOrigrnToCenter();
            p.Rotate(angle);
            p.Tags = tags;
            //add to list of particles, thanks again
            Particles.Add(p);
        }
        public static void CreateParticle(Vector2 position, Vector2 velocity, Vector2 size, Vector2 frameCount,
            string textureName, ContentManager content, UpdateParticle update, int TTL = 3000, float angle = 0, string tags = "")
        {
            //create particle, thanks cap
            Particle p = new Particle(velocity, position, size, textureName, frameCount, content);
            p.isRepeat = false;
            p.TTL = TTL;
            p.SetOrigrnToCenter();
            p.Rotate(angle);
            p.Update = update;
            p.Tags = tags;
            //add to list of particles, thanks again
            Particles.Add(p);
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
            //foreach (Particle p in Particles)
            for (int i = 0; i < Particles.Count; i++)
            {
                Particle p = Particles[i];
                //Move particle
                p.Move(p.Velocity);
                p.TOL += gameTime.ElapsedGameTime.Milliseconds;
                //Custom update if particle have it
                if (p.Update != null)
                    p.Update(ref p, ref Particles);
                //if time to die - kill particle
                if (p.TOL >= p.TTL)
                {
                    ToDelete.Add(p);
                }
            }

            foreach (Particle p in ToDelete)
                Particles.Remove(p);
        }
        public override void Draw(GameTime gameTime)
        {
            sBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone); //for pixels were pixels
            for (int i = 0; i < Particles.Count; i++)
            {
                Particle p = Particles[i];
                p.Draw(sBatch, gameTime);
            }
            sBatch.End();
        }

        public delegate void UpdateParticle(ref Particle particle, ref List<Particle> particles);
    }
}

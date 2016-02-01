using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace OridnaryRPG
{
    class Particle : Sprite
    {
        //Movement
        public Vector2 Velocity;
        //Life
        public int TTL; //Time to life
        public int TOL = 0; //Time of life
        //Tags (split by ",")
        public string Tags = "";
        //Update
        public ParticleSystem.UpdateParticle Update = null;

        public Particle(Vector2 velocity, Vector2 position, Vector2 size, string textureName, ContentManager content, int ttl = 3000)
            : base(content)
        {
            Velocity = velocity;
            LoadTexture(textureName, position, size);
            TTL = 3000;
        }
        public Particle(Vector2 velocity, Vector2 position, Vector2 size, string textureName, Vector2 frameCount, ContentManager content, bool isrepeat = true, int ttl = 3000)
            : base(content)
        {
            Velocity = velocity;
            LoadTexture(textureName, position, size, frameCount);
            TTL = ttl;
            isRepeat = isrepeat;
        }
    }
}

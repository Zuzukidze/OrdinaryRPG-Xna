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
        public string[] Tags;
        //is active (can't be restored)
        public bool isActive;
        
        /// <summary>
        /// basic particle constructor
        /// </summary>
        /// <param name="ttl">time to life</param>
        public Particle(Vector2 velocity, Vector2 position, Vector2 size, string textureName, ContentManager content, int ttl = 3000)
            : base(content)
        {
            Velocity = velocity;
            LoadTexture(textureName, position, size);
            TTL = 3000;
            isActive = true;
        }
        /// <summary>
        /// animated particle constructor
        /// </summary>
        /// <param name="frameCount">count of frame matrix</param>
        /// <param name="isrepeating">is animation repeating</param>
        /// <param name="ttl">time to life</param>
        public Particle(Vector2 velocity, Vector2 position, Vector2 size, string textureName, Vector2 frameCount, ContentManager content, bool isrepeating = true, int ttl = 3000)
            : base(content)
        {
            Velocity = velocity;
            LoadTexture(textureName, position, size, frameCount);
            TTL = ttl;
            isRepeating = isrepeating;
            isActive = true;
        }

        public virtual void Update(ref Particle[] particles, GameTime gametime)
        {
            base.Update(gametime);
        }
        /// <summary>
        /// check particle tags and return true if particle has tag
        /// </summary>
        /// <param name="tag">tag which method search</param>
        /// <returns></returns>
        public bool hasTag(string tag)
        {
            if (Tags != null)
                for (int i = 0; i < Tags.Length; i++)
                {
                    if (Tags[i].Equals(tag))
                        return true;
                }
            return false;
        }
    }
}

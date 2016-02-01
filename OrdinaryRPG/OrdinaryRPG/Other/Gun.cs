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
    public class Gun
    {
        public int BPS; //Bullets Per Second
        public int BulletsCount;
        public int MaxBulletsCount; //in 1 magazine
        public int MagazineCount;
        public int MaxMagazineCount;

        public string BulletTextureName;

        public int TimeFromLastShot;
        public int TimeForShot;

        public Gun(int bps, int bulletsCount, int maxBulletsCount, int magazineCount, int maxMagazineCount, string bulletTextureName)
        {
            BPS = bps;
            BulletsCount = bulletsCount;
            MaxBulletsCount = maxBulletsCount;
            MagazineCount = magazineCount;
            MaxMagazineCount = maxMagazineCount;
            TimeForShot = 1000 / BPS;
            TimeFromLastShot = 0;
            BulletTextureName = bulletTextureName;
        }

        public bool IsReady(GameTime gameTime)
        {
            if (TimeFromLastShot >= TimeForShot) // если прошло достаточно времени с момента последего выстрела
            {
                TimeFromLastShot = 0;
                return true;
            }
            return false;
        }
        public void Update(GameTime gameTime)
        {
            TimeFromLastShot += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeFromLastShot > TimeForShot) // если прошло достаточно времени с момента последего выстрела
            {
                TimeFromLastShot = TimeForShot;
            }
        }
        public void Shot(Vector2 start, Vector2 targ, GameTime gameTime, ContentManager Content)
        {
            if (IsReady(gameTime))
            {
                if (BulletsCount > 0)
                {
                    BulletsCount--;
                    Bullet b = new Bullet(start, targ, Content, gameTime);
                }
                else if (BulletsCount <= 0 && MagazineCount > 0)
                {
                    MagazineCount--;
                    BulletsCount = MaxBulletsCount;
                }
            }
        }
    }
}

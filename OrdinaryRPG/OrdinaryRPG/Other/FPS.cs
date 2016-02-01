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
    public class FPS : DrawableGameComponent
    {
        SpriteBatch sBatch;
        SpriteFont sFont;
        string sfontname;

        Vector2 pos;

        int fps = 0;
        int curfps = 0;
        double timefromlastframe;

        public FPS(Game game, string fontName, Vector2 position)
            : base(game)
        {
            sfontname = fontName;
            pos = position;
        }
        protected override void LoadContent()
        {
            sBatch = new SpriteBatch(GraphicsDevice);
            sFont = Game.Content.Load<SpriteFont>(sfontname);
        }
        public override void Update(GameTime gameTime)
        {
            timefromlastframe += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timefromlastframe >= 1000)
            {
                fps = curfps;
                curfps = 0;
                timefromlastframe = 0;
            }
        }
        public override void Draw(GameTime gameTime)
        {
            curfps++;
            sBatch.Begin();
            sBatch.DrawString(sFont, "FPS: " + fps, pos + Vector2.One, Color.Black);
            if (fps > 58)
                sBatch.DrawString(sFont, "FPS: " + fps, pos, Color.White);
            else
                sBatch.DrawString(sFont, "FPS: " + fps, pos, Color.Red);
            sBatch.End();
        }
    }
}

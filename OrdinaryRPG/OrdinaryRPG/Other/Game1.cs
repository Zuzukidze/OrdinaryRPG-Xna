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
using OrdinaryRPG.Sprites.Sprite_types.Block_types;
using OrdinaryRPG.Sprites.Sprite_types;
using OridnaryRPG.Sprites.Sprite_types;

namespace OridnaryRPG
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
         public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont sFont;
        Random r = new Random();
        public static Vector2 ScreenSize = new Vector2(1280, 960);
        public static Block[,] Map = new Block[20, 15];
        Vector2 MapSize = new Vector2(20, 15);
        int indexOfCursor = 0;
        int lastWheelState = 0;
        Block[] blockSet = new Block[2];
        //SPRITES
        Sprite cursor;
        Brick block;
        Button button;

        //Sprite player;
        Sprite player;
        


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = (int)ScreenSize.Y;
            graphics.PreferredBackBufferWidth = (int)ScreenSize.X;
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //Components
            Components.Add(new FPS(this, "Fonts\\Arial-10", new Vector2(Window.ClientBounds.Width / 2f, 0))); //Show FPS
            //Components.Add(new ParticleSystem(this)); //do almost everything with particles
            //Sprites
            cursor = new Sprite(Content); //mouse icon
            player = new Player(Content);
            //Bocks
            block = new Brick(Content);
            button = new Button(Content);
            blockSet[0] = block;
            blockSet[1] = button;

            base.Initialize();
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sFont = Content.Load<SpriteFont>("Fonts\\Arial-10");
            //mouse icon
            cursor.LoadTexture("dot", Vector2.Zero, new Vector2(16, 16));
            cursor.SetOrigrnToCenter();

            player.LoadTexture("HeroSpriteMap", new Vector2(640, 360), new Vector2(64, 80), new Vector2(4,5),5);
            player.ScaleX(new Vector2(4));
            player.SetOrigrnToCenter();

            block.LoadTexture("Block", new Vector2(0), new Vector2(16));
            block.ScaleX(new Vector2(4));
            block.Color *= .5f;

            button.LoadTexture("Button", new Vector2(0), new Vector2(32,16),new Vector2(2,1));
            button.ScaleX(new Vector2(4));
            button.Color *= .5f;
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            //how much time has passed
            float t = (float)gameTime.ElapsedGameTime.Milliseconds;


            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                int blockX = (int)Mouse.GetState().X / 64;
                int blockY = (int)Mouse.GetState().Y / 64;
                if (blockX < MapSize.X && blockY < MapSize.Y && blockX > -1 && blockY > -1)
                {
                    Map[blockX, blockY] = getBlock(indexOfCursor);// = new Sprite(Content);
                    Map[blockX, blockY].SetPosition(new Vector2(blockX * 64, blockY * 64));
                    /*Map[blockX, blockY].LoadTexture("Block", new Vector2(blockX * 64, blockY * 64), new Vector2(16));
                    Map[blockX, blockY].ScaleX(new Vector2(4));*/
                }
            }
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                int blockX = (int)Mouse.GetState().X / 64;
                int blockY = (int)Mouse.GetState().Y / 64;
                if (blockX < MapSize.X && blockY < MapSize.Y && blockX > -1 && blockY > -1)
                    Map[blockX, blockY] = null;
            }
            if (Mouse.GetState().ScrollWheelValue > lastWheelState)
                if (indexOfCursor == 0)
                    indexOfCursor = blockSet.Length - 1;
                else
                    indexOfCursor--;
            if (Mouse.GetState().ScrollWheelValue < lastWheelState)
                if (indexOfCursor == blockSet.Length - 1)
                    indexOfCursor = 0;
                else
                    indexOfCursor++;

            cursor.Color = Color.Black;
            cursor.SetPosition(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
            blockSet[indexOfCursor].SetPosition(new Vector2((int)Mouse.GetState().X - Mouse.GetState().X % 64, (int)Mouse.GetState().Y - Mouse.GetState().Y % 64));
            
            player.Update(gameTime);

            lastWheelState = Mouse.GetState().ScrollWheelValue;
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            //DRAW SPRITES
            string mousepos = (int)Mouse.GetState().X / 64 + " " + (int)Mouse.GetState().Y / 64;
            spriteBatch.DrawString(sFont, mousepos, new Vector2(0), Color.White);
            mousepos = (int)(player.getRect().X / 64) + " " + (int)(player.getRect().Y / 64);
            spriteBatch.DrawString(sFont, mousepos, new Vector2(0,10), Color.White);
            spriteBatch.DrawString(sFont, Mouse.GetState().ScrollWheelValue.ToString(), new Vector2(0, 20), Color.White);
            for (int y = 0; y < MapSize.Y; y++)
            {
                for (int x = 0; x < MapSize.X; x++)
                {
                    if (Map[x, y] != null)
                    {
                        Map[x, y].Draw(spriteBatch, gameTime);
                    }
                }
            }
            player.Draw(spriteBatch, gameTime);
            blockSet[indexOfCursor].Draw(spriteBatch, gameTime);
            //DRAW CURSOR
            cursor.Draw(spriteBatch, gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        public Block getBlock(int index)
        {
            Block Block;
            switch (index)
            {
                case 0:
                    Block = new Brick(Content);
                    Block.LoadTexture("Block", new Vector2(0), new Vector2(16));
                    Block.ScaleX(new Vector2(4));
                    break;
                case 1:
                    Block = new Button(Content);
                    Block.LoadTexture("Button", new Vector2(0), new Vector2(32,16),new Vector2(2,1));
                    Block.ScaleX(new Vector2(4));
                    break;
                default:
                    Block = null;
                    break;
            }
            return Block;
            
        }

    }
}

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LineDraw; 

namespace MHanks_Lab5
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : GameApp
    {
        Sprite Player;
        

        SpriteFont sF;

        float test = 50;
        float test2 = 100;


        //public List bullets = new List();
        public List<BaseGameObject> SceneList;
        public List<BaseGameObject> DestroyList;

        //TO DO: Make a list of gameobjects that calls their update functions


        public Game1()
        {
            SceneList = new List<BaseGameObject>();
            DestroyList = new List<BaseGameObject>();

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            // Setting up Screen Resolution
            // Read more here: http://rbwhitaker.wikidot.com/changing-the-window-size
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 960;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Player = new Sprite("Cursor");
            Player.scale = .025f;
            Player.position = new Vector2(1280/2, 960/2);
            Player.origin.X = Player.texture.Width / 2;
            Player.origin.Y = Player.texture.Height / 2;

           
          
           

            sF = Content.Load<SpriteFont>("Font");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void GameUpdate(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (IsKeyHeld(Keys.W))            //Up
            {
                Player.position.Y -= 7.5f;
            }
            if (IsKeyHeld(Keys.A))           //Left
            {
                Player.position.X -= 7.5f;
            }
            if (IsKeyHeld(Keys.S))           //Down
            {
                Player.position.Y += 7.5f;
            }
            if (IsKeyHeld(Keys.D))           //Right
            {
                Player.position.X += 7.5f;
            }
            if (IsKeyHeld(Keys.E))           //rotate clockwise
            {
                Player.rotation += .15f;
            }
            if (IsKeyHeld(Keys.Q))           //rotate counter-clockwise
            {
                Player.rotation -= .15f;
            }
            if (MouseButtonIsPressed("LeftButton") || IsKeyPressed(Keys.Space))      //shoot
            {
                FireBullet(gameTime);
            }


            // Update All Objects
            if (SceneList.Count > 0)
            {
                foreach (BaseGameObject go in SceneList)
                {
                    go.ObjectUpdate(gameTime);
                }
            }

            // Clean up objects that are for Destruction
            if (DestroyList.Count > 0)
            {
                foreach (BaseGameObject go in DestroyList)
                {
                    SceneList.Remove(go); 
                }
                DestroyList.Clear();
            }
        }

        public void FireBullet(GameTime gameTime)
        {
            Bullet b = new Bullet();
            b.Position = Player.position;
            b.Velocity = LinePrimatives.AngleToV2(MathHelper.ToDegrees(Player.rotation), b.moveSpeed);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            Player.Draw(spriteBatch);

            spriteBatch.DrawString(sF, "Player Position: " + Player.position, new Vector2(50, 50), Color.Aqua);

            // Draw items in our Scene List
            foreach (BaseGameObject go in SceneList)
            {
                go.ObjectDraw(spriteBatch);
                
            }
            spriteBatch.DrawString(sF, "ObjectList: " + SceneList.Count , new Vector2(50, test2 + test), Color.Aqua);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

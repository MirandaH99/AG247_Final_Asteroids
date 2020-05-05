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
        //Sprite Player;

        Player p;

        BaseGameObject bGO;

        TimeSpan ts = TimeSpan.FromSeconds(5);



        SpriteFont sF;

        float test = 50;
        float test2 = 100;



        //TO DO: Make a list of gameobjects that calls their update functions


        public Game1()
        {
       

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

            BaseGameObject.ScreenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);


            SetGame();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            sF = Content.Load<SpriteFont>("Font");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        public override void SetGame()
        {
            ClearScene(); 
            p = new Player();
            new Asteroids();
            new Asteroids();
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

            //if (ts.TotalSeconds <= 0)
            //{
            //    if (asteroids.numberOfAsteroids <= asteroids.maxAsteroids)
            //    {
            //        SpawnAsteroid(gameTime);
            //    }
            //    ts = TimeSpan.FromSeconds(5);
            //}

            ts -= gameTime.ElapsedGameTime;

            if (IsKeyHeld(Keys.W))            //Up
            {
                p.playerSprite.position.Y -= 7.5f;
            }
            if (IsKeyHeld(Keys.A))           //Left
            {
                p.playerSprite.position.X -= 7.5f;
            }
            if (IsKeyHeld(Keys.S))           //Down
            {
                p.playerSprite.position.Y += 7.5f;
            }
            if (IsKeyHeld(Keys.D))           //Right
            {
                p.playerSprite.position.X += 7.5f;
            }
            if (IsKeyHeld(Keys.E))           //rotate clockwise
            {
                p.playerSprite.rotation += .15f;
            }
            if (IsKeyHeld(Keys.Q))           //rotate counter-clockwise
            {
                p.playerSprite.rotation -= .15f;
            }
            if (MouseButtonIsPressed("LeftButton") || IsKeyPressed(Keys.Space))      //shoot
            {
                FireBullet(gameTime);
            }

            if (IsKeyPressed(Keys.Tab))           //Testing
            {
                Asteroids a = new Asteroids();
            
            }


        }

        public void FireBullet(GameTime gameTime)
        {
            Bullet b = new Bullet();
            b.Position = p.playerSprite.position;
            b.Velocity = LinePrimatives.AngleToV2(MathHelper.ToDegrees(p.playerSprite.rotation), b.moveSpeed);
        }

        public void SpawnAsteroid(GameTime gameTime)
        {
            //Random randoNum = new Random();
            //Asteroids a = new Asteroids();
            //a.Position = new Vector2(0, bGO.ScreenSize.Y);
            //a.Velocity = LinePrimatives.AngleToV2(MathHelper.ToDegrees(), a.moveSpeed);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            //p.playerSprite.Draw(spriteBatch);

            spriteBatch.DrawString(sF, "Player Position: " + p.playerSprite.position, new Vector2(50, 50), Color.Aqua);

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

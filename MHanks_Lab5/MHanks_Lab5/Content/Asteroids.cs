using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LineDraw;


namespace MHanks_Lab5
{
    class Asteroids : BaseGameObject
    {
        private Sprite asteroidSprite;

        public float moveSpeed = 50;

        public float numberOfAsteroids = 0;

        public float maxAsteroids = 10;

       


        public override void InitalizeObject()
        {
            // set these in child classes... 
            asteroidSprite = new Sprite("Cat");
            asteroidSprite.scale = .25f;
            asteroidSprite.origin.X = asteroidSprite.texture.Width / 2;
            asteroidSprite.origin.Y = asteroidSprite.texture.Height / 2;

            Collision = new Rectangle(0, 0, (int)(asteroidSprite.texture.Width * asteroidSprite.scale), (int)(asteroidSprite.texture.Height * asteroidSprite.scale));

            SetSpawnandHeading(); 
        }

        public virtual void SetSpawnandHeading()
        {
            Vector2 Spawnlocation = Vector2.Zero;
            Vector2 HeadingLocation = Vector2.Zero;
            int side = GameApp.random.Next(4);

            if (side == 0) // Left
            {
                Spawnlocation.X = -ScreenBuffer;
                Spawnlocation.Y = GameApp.random.Next((int)ScreenSize.Y);
                HeadingLocation.X = ScreenSize.X + ScreenBuffer;
                HeadingLocation.Y = GameApp.random.Next((int)ScreenSize.Y);
            }
            if (side == 1) // Right
            {
                Spawnlocation.X = ScreenSize.X + ScreenBuffer;
                Spawnlocation.Y = GameApp.random.Next((int)ScreenSize.Y);
                HeadingLocation.X = -ScreenBuffer;
                HeadingLocation.Y = GameApp.random.Next((int)ScreenSize.Y);
            }
            if (side == 2) // Top
            {
                Spawnlocation.X = GameApp.random.Next((int)ScreenSize.X);
                Spawnlocation.Y = -ScreenBuffer;
                HeadingLocation.X = GameApp.random.Next((int)ScreenSize.X);
                HeadingLocation.Y = ScreenSize.Y + ScreenBuffer;
            }
            if (side == 3) // Bottom
            {
                Spawnlocation.X = GameApp.random.Next((int)ScreenSize.X);
                Spawnlocation.Y = ScreenSize.Y + ScreenBuffer;
                HeadingLocation.X = GameApp.random.Next((int)ScreenSize.X);
                HeadingLocation.Y = -ScreenBuffer;
            }

            Position = Spawnlocation;
            asteroidSprite.position = Spawnlocation;

            Velocity = (HeadingLocation - Spawnlocation);
            Velocity.Normalize();
            Velocity *= moveSpeed; 
            
        }

        public override void Update(GameTime gameTime)
        {
            Collision.Location = (Position - (asteroidSprite.origin * asteroidSprite.scale)).ToPoint();

            if ((Position.X >= ScreenSize.X || Position.Y >= ScreenSize.Y) || (Position.X <= 0 || Position.Y <= 0))
            {
                Destroy();
                return; 
            }

            CheckForCollisions(); 

        }

        public override void OnCollision(BaseGameObject other)
        {
            if (other is Asteroids)
            {
                return; 
            }

            Destroy();
            other.Destroy();
            
            new Asteroids();
            new Asteroids();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            asteroidSprite.position = Position;
            if (Collision != null)
            {
                LinePrimatives.DrawRectangle(spriteBatch, 3, Color.Red, Collision);
            }
            asteroidSprite.Draw(spriteBatch);
        }
    }
}

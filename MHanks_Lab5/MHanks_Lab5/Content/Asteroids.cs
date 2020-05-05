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

        public float moveSpeed;

        public float numberOfAsteroids = 0;

        public float maxAsteroids = 10;

        public Rectangle asterRectangle;

        public Asteroids()
        {

        }

        public override void InitalizeObject()
        {
            // set these in child classes... 
            asteroidSprite = new Sprite("Cat");
            asteroidSprite.scale = .025f;
            asteroidSprite.origin.X = asteroidSprite.texture.Width / 2;
            asteroidSprite.origin.Y = asteroidSprite.texture.Height / 2;

            // Set this a object creation
            //Position = center; 

            moveSpeed = 50;

            Velocity = LinePrimatives.AngleToV2(Rotation, moveSpeed);

            //Velocity.X = moveSpeed;
            //Velocity.Y = moveSpeed;


            asterRectangle = new Rectangle(0, 0, asteroidSprite.texture.Width, asteroidSprite.texture.Height);

        }

        public override void Update(GameTime gameTime)
        {
            asterRectangle.Location = Position.ToPoint();

            if ((Position.X >= ScreenSize.X || Position.Y >= ScreenSize.Y) || (Position.X <= 0 || Position.Y <= 0))
            {
                Destroy();
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            asteroidSprite.position = Position;
            asteroidSprite.Draw(spriteBatch);
        }
    }
}

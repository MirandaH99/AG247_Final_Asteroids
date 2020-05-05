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
    class Player:BaseGameObject
    {

        public Sprite playerSprite;

        public float moveSpeed;

        public Rectangle playerRectangle;

        public Player()
        {

        }

        public override void InitalizeObject()
        {

            playerSprite = new Sprite("Cursor");
            playerSprite.scale = .025f;
            playerSprite.position = new Vector2(1280 / 2, 960 / 2);
            playerSprite.origin.X = playerSprite.texture.Width / 2;
            playerSprite.origin.Y = playerSprite.texture.Height / 2;

            // Set this a object creation
            //Position = center; 

            moveSpeed = 50;

            Velocity = LinePrimatives.AngleToV2(Rotation, moveSpeed);

            //Velocity.X = moveSpeed;
            //Velocity.Y = moveSpeed;


            playerRectangle = new Rectangle(0, 0, playerSprite.texture.Width, playerSprite.texture.Height);

        }

        public override void Update(GameTime gameTime)
        {
            Position = playerSprite.position;

            playerRectangle.Location = Position.ToPoint();

            if (Position.X >= ScreenSize.X)
            {
                playerSprite.position.X = 1;
            }

            if (Position.Y >= ScreenSize.Y)
            {
                playerSprite.position.Y = 1;
            }

            if (Position.X <= 0)
            {
                playerSprite.position.X = ScreenSize.X - 1;
            }

            if (Position.Y <= 0)
            {
                playerSprite.position.Y = ScreenSize.Y - 1;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
   
            playerSprite.Draw(spriteBatch);
        }

    }
}

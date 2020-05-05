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

       
        public Player()
        {

        }

        public override void InitalizeObject()
        {

            playerSprite = new Sprite("Cursor");
            playerSprite.scale = .025f;
            playerSprite.position = (ScreenSize / 2);
            playerSprite.origin.X = playerSprite.texture.Width / 2;
            playerSprite.origin.Y = playerSprite.texture.Height / 2;

            // Set this a object creation
            //Position = center; 

            moveSpeed = 50;

            Velocity = LinePrimatives.AngleToV2(Rotation, moveSpeed);

            //Velocity.X = moveSpeed;
            //Velocity.Y = moveSpeed;


            Collision = new Rectangle(0, 0, (int) (playerSprite.texture.Width* playerSprite.scale), (int)(playerSprite.texture.Height * playerSprite.scale));

        }

        public override void Update(GameTime gameTime)
        {
            Position = playerSprite.position;

            Collision.Location = Position.ToPoint();

            if (Position.X > ScreenSize.X + ScreenBuffer)
            {
                playerSprite.position.X  = -ScreenBuffer;
            }

            if (Position.Y > ScreenSize.Y + ScreenBuffer)
            {
                playerSprite.position.Y = -ScreenBuffer;
            }

            if (Position.X < -ScreenBuffer)
            {
                playerSprite.position.X = ScreenSize.X + ScreenBuffer;             
            }

            if (Position.Y < -ScreenBuffer)
            {
                playerSprite.position.Y = ScreenSize.Y + ScreenBuffer;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Collision != null)
            {
                LinePrimatives.DrawRectangle(spriteBatch, 3, Color.Red, Collision);
            }
            playerSprite.Draw(spriteBatch);
        }

        public override void OnDestroy()
        {
            isActive = false;
            GameApp.instance.SetGame(); 
        }
    }
}

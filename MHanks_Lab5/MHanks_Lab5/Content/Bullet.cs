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
    public class Bullet : BaseGameObject
    {
        // credit to https://huskylogan.wordpress.com/2012/08/08/firing-projectiles-in-xna/ for help with creating projectile

        private Sprite bulletSprite;

        public float moveSpeed;
        public Rectangle bulletRectangle;

        public Bullet()
        {
          
        }

        public override void InitalizeObject()
        {
            // set these in child classes... 
            bulletSprite = new Sprite("heart");
            bulletSprite.scale = .025f;
            bulletSprite.origin.X = bulletSprite.texture.Width / 2;
            bulletSprite.origin.Y = bulletSprite.texture.Height / 2;

            // Set this a object creation
            //Position = center; 

            moveSpeed = 50;

            Velocity = LinePrimatives.AngleToV2(Rotation, moveSpeed); 

            //Velocity.X = moveSpeed;
            //Velocity.Y = moveSpeed;
    

            bulletRectangle = new Rectangle(0, 0, bulletSprite.texture.Width, bulletSprite.texture.Height);


        }

        public override void Update(GameTime gameTime)
        {        
            bulletRectangle.Location = Position.ToPoint(); 

            if((Position.X>= ScreenSize.X || Position.Y >= ScreenSize.Y) || (Position.X <= 0 || Position.Y <= 0))
            {
                Destroy();
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            bulletSprite.position = Position; 
            bulletSprite.Draw(spriteBatch);
        }

      
    }
}

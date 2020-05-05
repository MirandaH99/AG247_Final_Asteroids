using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MHanks_Lab5
{
    public class BaseGameObject
    {
        public static Vector2 ScreenSize = new Vector2(1280, 960);
        public static int ScreenBuffer = -100; 

        public bool isActive = true;
        public Vector2 Position = Vector2.Zero;
        public Vector2 Scale = Vector2.Zero;
        public float Rotation = 0;
        public Vector2 Velocity;
        public bool HasMaxiumVelocity = false; 
        public float MaxiumVelocity = float.MaxValue;
        public Rectangle Collision;
        public BaseGameObject owner = null;
        public bool IgnoreOwner = false; 



        public BaseGameObject()
        {
            GameApp.instance.AddList.Add(this); 

            InitalizeObject(); 
        }

        public virtual void InitalizeObject()
        {

        }

        public void ObjectUpdate(GameTime gameTime)
        {
            if (isActive)
            {

              
                if (HasMaxiumVelocity)
                { 
                    ScrubVelocity();
                }

                float gT = (float)gameTime.ElapsedGameTime.TotalSeconds;
                Position += Velocity * gT;
                Update(gameTime);



            }
        }


        public virtual void CheckForCollisions()
        {
            foreach (BaseGameObject obj in GameApp.instance.SceneList)
            {
                if (obj == this) // ignore ourself 
                {
                    continue;
                }
                if (owner != null)
                {
                    if ((obj == owner) && IgnoreOwner)
                    {
                        continue;
                    }
                   
                }

                if (this.Collision.Intersects(obj.Collision))
                {
                    OnCollision(obj); 
                }


            }
        }

        public virtual void OnCollision(BaseGameObject other)
        {

        }

        public void ScrubVelocity()
        {
            if ( Velocity.Length() > MaxiumVelocity)
            {
                Velocity.Normalize(); 
                Velocity *= MaxiumVelocity; 
            }
        }

        public  virtual void Update(GameTime gameTime)
        {
            

        }

        public void ObjectDraw(SpriteBatch spriteBatch)
        {
            if (isActive)
            {
                Draw(spriteBatch);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {


        }

        public void Destroy(bool CallOnDestroy = true)
        {
            if (CallOnDestroy)
            {
                OnDestroy();
            }
            GameApp.instance.DestroyList.Add(this);
        }

        public virtual void OnDestroy()
        {
            isActive = false;
        }


    }
}

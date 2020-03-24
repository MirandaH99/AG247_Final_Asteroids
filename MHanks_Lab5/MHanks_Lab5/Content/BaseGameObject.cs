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
        public Vector2 ScreenSize = new Vector2(1280, 960);

        public bool isActive = true;
        public Vector2 Position = Vector2.Zero;
        public Vector2 Scale = Vector2.Zero;
        public float Rotation = 0;
        public Vector2 Velocity;
        public bool HasMaxiumVelocity = false; 
        public float MaxiumVelocity = float.MaxValue; 
        

        public BaseGameObject()
        {
            ((Game1)GameApp.instance).SceneList.Add(this); 

            InitalizeObject(); 
        }

        public virtual void InitalizeObject()
        {

        }

        public void ObjectUpdate(GameTime gameTime)
        {
            if (isActive)
            {

                Update(gameTime);
                if (HasMaxiumVelocity)
                { 
                    ScrubVelocity();
                }

                float gT = (float)gameTime.ElapsedGameTime.TotalSeconds;
                Position += Velocity * gT;
            }
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

        public void Destroy()
        {
            OnDestroy(); 
            ((Game1)GameApp.instance).DestroyList.Add(this);
        }

        public virtual void OnDestroy()
        {
            isActive = false;
        }


    }
}

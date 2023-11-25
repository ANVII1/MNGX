using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MNGX.Engine.Managers;
using MNGX.Engine.Renderer;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MNGX.Engine.models
{
    public abstract class GameObject
    {
        public bool colision;
        protected Vector2 speed;
        protected Vector2 speedlimit;
        protected float weight;

        protected float layerDepth;
        protected Vector2 position;
        protected float rotation;
        protected Vector2 origin;
        protected Vector2 scale;
        protected SpriteEffects spriteEffects;

        protected GameObject(Vector2 position, float rotation, Vector2 scale, float layerDepth, SpriteEffects spriteEffects) 
        { 
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.layerDepth = layerDepth;
            this.spriteEffects = spriteEffects;
            colision = false;
        }
        public virtual void update() { }
        public abstract void draw();
        public abstract Rectangle getCurrnetRectangle();


        #region colission

        public virtual void CheckCollision(List<GameObject> gameObjects) 
        { 
            foreach (GameObject obj in gameObjects) 
            {
                if (obj == this | !obj.colision)
                    continue;
                

            }
        }
        protected virtual void getLeft() { }
        protected virtual void getRight() { }
        protected virtual void getTop() { }
        protected virtual void getBottom() { }

        //prot

        #endregion
    }

    // ///////////////////// ОБЪЕКТЫ БЕЗ АНИМАЦИИ
    public class StaticGameObject : GameObject
    {
        protected Texture2D texture;
        private Rectangle rectangle;

        protected StaticGameObject(Texture2D texture, Vector2 position, Vector2 scale, float rotation = 0, float layerDepth = 1, SpriteEffects spriteEffects = SpriteEffects.None) 
            : base(position,rotation,scale,layerDepth,spriteEffects)
        {
            this.texture = texture;
            rectangle= new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
        public override void draw()
        {
            Globals.SpriteBatch.Draw(texture,position,rectangle,Color.White,rotation,origin,scale, spriteEffects,layerDepth);
        }
        public override Rectangle getCurrnetRectangle()
        {
            return rectangle;
        }
    }

    // ///////////////////// АНИМИРОВАННЫЕ ОБЪЕКТЫ
    public class AnimatedGameObject : GameObject
    {
        protected AnimationManager animations;

        protected AnimatedGameObject(Vector2 position, Vector2 scale, float rotation = 0, float layerDepth = 1, SpriteEffects spriteEffects = SpriteEffects.None)
            : base(position, rotation, scale, layerDepth, spriteEffects)
        { 
            animations = new AnimationManager();
        }

        public void updateAnimation(string key) // Нужно будет вызывать во всех классах наследниках в update при изменении анимации 
        {
            animations.update(key);
        }

        public override void draw() 
        {
            animations.draw(position,rotation,scale,layerDepth,spriteEffects);
        }

        public override Rectangle getCurrnetRectangle() 
        {
            return animations.getCurrentRectangle();
        }
    }
}

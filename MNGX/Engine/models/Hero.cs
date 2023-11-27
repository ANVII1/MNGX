using Microsoft.Xna.Framework.Graphics;
using MNGX.Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MNGX.Engine.models
{
    public class Hero : AnimatedGameObject
    {
        public Hero(Vector2 position)
            : base(GameObjectType.player, position, 2.0f, layerDepth:0.7f)
        {
            colision = true;

            Texture2D texture = Globals.Content.Load<Texture2D>("textures/HeroAnim");

            this.AddAnimation("walkLeft", new Animation(texture,6, 4,0.2f, 2));
            this.AddAnimation("walkRight", new Animation(texture, 6, 4, 0.2f, 4));

            this.AddAnimation("idleLeft", new Animation(texture, 6, 4, 0.2f,1));
            this.AddAnimation("idleRight", new Animation(texture, 6, 4, 0.2f, 3));
            // this.spriteEffects = SpriteEffects.FlipHorizontally; - Тупа отражает текстуру по горизонтали
            this.position = position;

            speed = Vector2.Zero;
            speedlimit.X = 3;
            speedlimit.Y = 20;
            weight = 1.0f;

        }
        
        public override void update()
        {
            KeyboardState kb = Keyboard.GetState();
            updateAnimation("idleRight");
            if (kb.IsKeyDown(Keys.W)) 
            {
                speed.Y -= 0.3f;
            }
            if (kb.IsKeyDown(Keys.A))
            {
                speed.X -= 0.3f;
            }
            if (kb.IsKeyDown(Keys.S))
            {
                speed.Y += 0.3f;
            }
            if (kb.IsKeyDown(Keys.D))
            {
                speed.X += 0.3f;
            }
            position += speed;

            // inert
            speed.Y += (0.1f * -1); // Чисти давай вилкой, чисти
            speed.X += (0.1f * -1);
        }
    }
}
 
using Microsoft.Xna.Framework.Graphics;
using MNGX.Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace MNGX.Engine.models;
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
        speedlimit.X = 4f;
        speedlimit.Y = 4f;
        weight = 1.0f;

    }
        
    public override void update()
    {
        var sc = Globals.sceneManager.getActiveScene();

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
        if (kb.IsKeyDown(Keys.Space))
        {
            Globals.sceneManager.addObjectToActiveScene(new Projectile(position));
        }
        position += speed;



        // inert
        if (kb.IsKeyUp(Keys.W)  && kb.IsKeyUp(Keys.S))
        {
            speed.Y += (float)(0.5f * -(Math.Sign(speed.Y)));   
            if (speed.Y < 0.20f && speed.Y > -0.20f) speed.Y = 0;
        }
        if (kb.IsKeyUp(Keys.D) && kb.IsKeyUp(Keys.A))
        {
            if (speed.X < 0.20f && speed.X > -0.20f) speed.X = 0;
            speed.X += (float)(0.5f * -(Math.Sign(speed.X)));
        }

        // speedlimit
        if (speed.X >= speedlimit.X || speed.X <= speedlimit.X * -1) speed.X = speedlimit.X * Math.Sign(speed.X);
        if (speed.Y >= speedlimit.Y || speed.Y <= speedlimit.Y * -1) speed.Y = speedlimit.Y * Math.Sign(speed.Y);


    }
}

public class Projectile : StaticGameObject
{
    public Projectile(Vector2 position) 
        : base(
            GameObjectType.projectile, 
            Globals.Content.Load<Texture2D>("textures/projectile"),
            position,
            3
            )
    {
        speed.X = 5;
        speed.Y = 0;
    }

    public override void update() 
    {
        position += speed;
    }
}
 
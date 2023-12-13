using Microsoft.Xna.Framework.Graphics;
using MNGX.Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

using System.Threading;
using MNGX.Engine.Core;

namespace MNGX.Engine.models;
public class Hero : AnimatedGameObject
{
    Weapon weapon;
    public Hero(Vector2 position)
        : base(GameObjectType.player, position, 2.0f, layerDepth:0.7f)
    {
        colision = true;
        float sclae = scale;
        Texture2D texture = Globals.Content.Load<Texture2D>("textures/HeroAnim");

        this.AddAnimation("walkLeft", new Animation(texture,6, 4,0.2f, 2, scale));
        this.AddAnimation("walkRight", new Animation(texture, 6, 4, 0.2f, 4, scale));

        this.AddAnimation("idleLeft", new Animation(texture, 6, 4, 0.2f,1, scale));
        this.AddAnimation("idleRight", new Animation(texture, 6, 4, 0.2f, 3, scale));
        // this.spriteEffects = SpriteEffects.FlipHorizontally; - Тупа отражает текстуру по горизонтали
        this.position = position;

        speed = Vector2.Zero;
        speedlimit.X = 4f;
        speedlimit.Y = 4f;
        weight = 1.0f;

        weapon = new AssaultRifle(this);

    }
        
    public override void update()
    {
        var ms = Mouse.GetState();

        double angle = Math.Atan2(
            position.Y - ms.Y,
            position.X - ms.X
            );

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
        if (ms.LeftButton == ButtonState.Pressed)
        {
            weapon.use();
        }
        position += speed;

        // inert
        if (kb.IsKeyUp(Keys.W)  && kb.IsKeyUp(Keys.S))
        {
            speed.Y += (float)(0.5f * -(Math.Sign(speed.Y)));   
            if (speed.Y < 0.30f && speed.Y > -0.20f) speed.Y = 0;
        }
        if (kb.IsKeyUp(Keys.D) && kb.IsKeyUp(Keys.A))
        {
            if (speed.X < 0.30f && speed.X > -0.20f) speed.X = 0;
            speed.X += (float)(0.5f * -(Math.Sign(speed.X)));
        }

        // speedlimit
        if (speed.X >= speedlimit.X || speed.X <= speedlimit.X * -1) speed.X = speedlimit.X * Math.Sign(speed.X);
        if (speed.Y >= speedlimit.Y || speed.Y <= speedlimit.Y * -1) speed.Y = speedlimit.Y * Math.Sign(speed.Y);
    }
}

public abstract class Weapon 
{
    protected float lastShoot;
    protected float delay;
    protected float recoil;
    protected Hero owner;
    protected int spread;
    protected float ProjectileSpeed;
    protected anTimer span;

    public abstract void use();
}

public class AssaultRifle : Weapon
{
    public AssaultRifle(Hero owner) 
    { 
        this.owner = owner;
        delay = 2;
        span = new anTimer(200);
        recoil = 0;
        spread = 0;
        ProjectileSpeed = 10;
    }
    public override void use()
    {
        if (!span.checkDelay())
            return;
        
        var ms = Mouse.GetState();

        Random r = new Random();
        var targetPos = Globals.camera.ScreenToWorldSpace(new Vector2(ms.X, ms.Y));
        targetPos.X += (float)r.Next(-spread, spread);
        targetPos.Y += (float)r.Next(-spread, spread);
        Globals.sceneManager.addObjectToActiveScene(
            new Projectile(
                owner.Position,
                targetPos,
                ProjectileSpeed));
    }
}

public class Projectile : StaticGameObject
{
    public Projectile(Vector2 position, Vector2 target, float speed) 
        : base(
            GameObjectType.projectile, 
            Globals.Content.Load<Texture2D>("textures/projectile"),
            position,
            2
            )
    {
        double angle = Math.Atan2(
            position.Y-target.Y,
            position.X-target.X
            );

        this.speed = new Vector2(
            -(float) Math.Cos(angle) * speed,
            -(float) Math.Sin(angle) * speed
            );
        rotation = (float) angle;
        spriteEffects = SpriteEffects.FlipHorizontally;
    }

    public override void update() 
    {
        position += speed;
    }
}
 
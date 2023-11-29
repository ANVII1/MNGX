using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MNGX.Engine.models;

public abstract class GameObject
{
    protected Vector2 speed;
    protected Vector2 speedlimit;
    protected float weight;
    public bool colision;
    public GameObjectType type;

    protected float layerDepth;
    public Vector2 position { get; protected set; }
    protected float rotation;
    protected Vector2 origin;
    protected float scale;
    protected SpriteEffects spriteEffects;

    protected GameObject(GameObjectType type, Vector2 position, float rotation, float scale, float layerDepth, SpriteEffects spriteEffects)
    {
        this.type = type;
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
        this.layerDepth = layerDepth;
        this.spriteEffects = spriteEffects;
        this.colision = false;
    }
    public virtual void update() { }
    public virtual void draw() { }

    public abstract Rectangle getCurrnetRectangle();

    protected ContactType CheckCollision(Rectangle selfRect, Rectangle rect)
    // Возвращает сторону которой соприкосаются прямоугольники
    {
        if (rect.Top >= selfRect.Top && rect.Bottom <= selfRect.Top && selfRect.Left <= rect.Right)
            return ContactType.left;
        if (rect.Top >= selfRect.Top && rect.Bottom <= selfRect.Top && selfRect.Right >= rect.Left)
            return ContactType.right;
        if (selfRect.Left <= rect.Right && selfRect.Left >= rect.Left && selfRect.Top <= rect.Top && selfRect.Top >= rect.Bottom)
            return ContactType.top;
        if (selfRect.Left <= rect.Right && selfRect.Left >= rect.Left && selfRect.Top <= rect.Top && selfRect.Top >= rect.Bottom)
            return ContactType.bottom;
        return ContactType.none;
    }

    protected bool Intersec(Rectangle selfRect, Rectangle rect)
    // Проверяет пересечение
    {
        return selfRect.Intersects(rect);
    }
}

public enum ContactType
{
    left, right, top, bottom, none
}

public enum GameObjectType
{
    enemy, player, floor, wall, projectile
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MNGX.Engine.Core;

namespace MNGX.Engine.models;

public abstract class GameObject
{
    protected Vector2 speed;
    protected Vector2 speedlimit;
    protected Color color;
    
    protected float weight;
    public bool colision;
    public GameObjectType type;

    protected float layerDepth;
    public abstract Rect Collision_Rect { get; } // Для коллизии
    public abstract Vector2 Position { get; protected set; }
    protected Vector2 position;

    protected float rotation;
    protected Vector2 origin;
    protected float scale;
    protected SpriteEffects spriteEffects;

    protected GameObject(GameObjectType type, Vector2 position, float rotation, float scale, float layerDepth, SpriteEffects spriteEffects)
    {
        this.type = type;
        this.Position = position;
        this.rotation = rotation;
        this.scale = scale;
        this.layerDepth = layerDepth;
        this.spriteEffects = spriteEffects;
        this.colision = false;
        this.color = Color.White;
    }
    public virtual void update() { }
    public virtual void draw() { }
}

public enum GameObjectType
{
    enemy, player, floor, wall, projectile
}
using Microsoft.Xna.Framework.Graphics;
using MNGX.Engine.Managers;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MNGX.Engine.models;

// ///////////////////// АНИМИРОВАННЫЕ ОБЪЕКТЫ
public class AnimatedGameObject : GameObject
{
    private Dictionary<string, Animation> anims = new();
    private string lastKey;

    protected AnimatedGameObject(
        GameObjectType type,
        Vector2 position,
        float scale,
        float rotation = 0,
        float layerDepth = 1,
        SpriteEffects spriteEffects = SpriteEffects.None
    )
    : base(type, position, rotation, scale, layerDepth, spriteEffects)
    {

    }

    public void AddAnimation(string key, Animation animation)
    {
        anims.Add(key, animation);
        lastKey ??= key;
    }

    public void updateAnimation(string key) // Нужно будет вызывать во всех классах наследниках в update при изменении анимации 
    {
        if (anims.TryGetValue(key, out Animation value))
        {
            value.Start();
            anims[key].Update();
            lastKey = key;
        }
        else
        {
            anims[lastKey].Stop();
            anims[lastKey].Reset();
        }
    }

    public override void draw()
    {
        anims[lastKey].draw(position, rotation, scale, layerDepth, spriteEffects);
    }

    public override Rectangle getCurrnetRectangle()
    {
        return anims[lastKey].getCurrentRectangle();
    }
}

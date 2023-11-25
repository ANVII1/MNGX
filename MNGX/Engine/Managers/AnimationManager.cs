using MNGX.Engine.Renderer;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace MNGX.Engine.Managers;

public class AnimationManager { 

    private Dictionary<string, Animation> anims = new();
    private string lastKey;

    public void AddAnimation(string key, Animation animation)
    {
        anims.Add(key, animation);
        lastKey ??= key;
    }

    public Rectangle getCurrentRectangle() 
    {
        return anims[lastKey].getCurrentRectangle();
    }
    
    public void update(string key)
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

    public void draw(Vector2 pos, float rotation, Vector2 scale, float layerDepth, SpriteEffects spriteEffects)
    {
        anims[lastKey].draw(pos, rotation, scale, layerDepth, spriteEffects);
    }
}

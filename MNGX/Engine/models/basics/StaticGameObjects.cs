using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;

namespace MNGX.Engine.models;
// ///////////////////// ОБЪЕКТЫ БЕЗ АНИМАЦИИ
public class StaticGameObject : GameObject
{
    protected Texture2D texture;
    private Rectangle commonRectangle;
    private Rectangle elementRectangle;
    private int sizeScale;

    protected StaticGameObject(
        GameObjectType type,
        Texture2D texture,
        Vector2 position,
        float textureScale,
        int sizeScale = 1,
        float rotation = 0,
        float layerDepth = 1,
        SpriteEffects spriteEffects = SpriteEffects.None
        )
        : base(type, position, rotation, textureScale, layerDepth, spriteEffects)
    {
        this.texture = texture;
        this.sizeScale = sizeScale;
        commonRectangle = new Rectangle(0, 0, texture.Width * sizeScale, texture.Height * sizeScale);
        elementRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
    }

    public override void draw()
    {
        if (texture == null)
            throw new Exception("У статического объекта должна быть текстура");

        var sswidth = sizeScale;
        var ssheight = sizeScale;
        while (ssheight > 0)
        {
            sswidth = sizeScale;
            ssheight--;
            while (sswidth > 0)
            {
                sswidth--;
                var offset = new Vector2((sswidth * scale * texture.Width) + position.X, (ssheight * scale * texture.Height) + position.Y);
                Globals.SpriteBatch.Draw(texture, offset, elementRectangle, Color.White, rotation, origin, scale, spriteEffects, layerDepth);

            }
        }
    }
    public override Rectangle getCurrnetRectangle()
    {
        return commonRectangle;
    }
}

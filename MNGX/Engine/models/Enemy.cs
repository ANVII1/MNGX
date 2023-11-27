using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MNGX.Engine.models;
public class Enemy : StaticGameObject
{
    public Enemy(Vector2 position)
    : base(
        GameObjectType.enemy,
        Globals.Content.Load<Texture2D>("textures/Enemy"),
        position,
        3
        ) 
    {
        
    }
}

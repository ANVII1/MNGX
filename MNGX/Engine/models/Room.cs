using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MNGX.Engine.models
{
    public class Room : StaticGameObject
    {
        public Room(Vector2 pos)
            : base(
                  GameObjectType.floor,
                  Globals.Content.Load<Texture2D>("textures/stone"),
                  pos,
                  4.0f,
                  6,
                  layerDepth:0.2f
                  )
        {

        }
    }
}

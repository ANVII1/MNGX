using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.ComponentModel.DataAnnotations;

namespace MNGX.Engine.models;
public class Enemy : StaticGameObject
{
    public Enemy(Vector2 position)
    : base(
        GameObjectType.enemy,
        Globals.Content.Load<Texture2D>("textures/Enemy"),
        position,
        2
        ) 
    {
        
    }
    public override void update()
    {
        var scene = Globals.sceneManager.getActiveScene();
        foreach (GameObject go in scene.gameObjects)
        {
            if (go.type == GameObjectType.player)
                Globals.gameWindow.Title = $"MNGX TOP:{go.Collision_Rect.Top}, {Collision_Rect.Top}  Right:{go.Collision_Rect.Right}, {Collision_Rect.Right}, Left:{go.Collision_Rect.Left}, {Collision_Rect.Left}, Bottom:{go.Collision_Rect.Bottom}, {Collision_Rect.Bottom}";

            if ((go.type == GameObjectType.player) &&  Collision_Rect.Intersect(go.Collision_Rect)) 
            {
                color = Color.Red;
                return;
            }
        }
        color = Color.White;
    }
}

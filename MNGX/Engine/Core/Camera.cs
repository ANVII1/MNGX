using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MNGX.Engine.models;
using System;

namespace MNGX.Engine.Core;
public class Camera
{
    /*
         Наебашить тут дополнительно deley что бы камера не была такая дёрганая
            что ьы сука с задержечкой двигаласть через 0.2cек после того как перс начал двигаться
         и сделать что бы это происходило плавно
    */

    public Matrix Transform { get; private set; }

    public Camera() 
    {
        Transform = Matrix.CreateTranslation(
            Globals.ScreenWidth / 2,
            Globals.ScreenHeight / 2,
            0);
    }

    public Vector2 ScreenToWorldSpace(Vector2 point)
    {
        Matrix invertedMatrix = Matrix.Invert(Transform);
        return Vector2.Transform(point, invertedMatrix);
    }

    public void Follow(Vector2 target)
    {
        var position = Matrix.CreateTranslation(
            -target.X ,
            -target.Y ,
            0);

        var offset = Matrix.CreateTranslation(
            Globals.ScreenWidth / 2,
            Globals.ScreenHeight / 2,
            0);

        Transform = position * offset;
    }


    public void HeroFollow(GameObject origin)
    {
        var ms = Mouse.GetState();
        Vector2 cursor = ScreenToWorldSpace(new Vector2(ms.X,ms.Y));

        var originRect = origin.Collision_Rect;
        var target = new Vector2(
            ((originRect.X  + cursor.X) / 2),
            ((originRect.Y + cursor.Y) / 2)
            );

        Follow(target);
    }
}


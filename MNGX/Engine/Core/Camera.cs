using Microsoft.Xna.Framework;
using MNGX.Engine.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNGX.Engine.Core;
public class Camera
{
    public Matrix Transform { get; private set; }

    public Camera() 
    {
        Transform = new Matrix();
    }

    public void Follow(GameObject target)
    {
        var targetRect = target.getCurrnetRectangle();
        var position = Matrix.CreateTranslation(
            -target.position.X - (targetRect.Width / 2),
            -target.position.Y - (targetRect.Height / 2),
            0);

        var offset = Matrix.CreateTranslation(
            Globals.ScreenWidth / 2,
            Globals.ScreenHeight / 2,
            0);

        Transform = position * offset;
    }
}


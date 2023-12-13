using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MNGX.Engine.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNGX.Engine.Core;

public class Rect
{
    private float x, y, width, height, top, bottom, left, right;
    public Rect(float x, float y, float width, float height)
    {
        this.height = height;
        this.width = width;
        this.X = x;
        this.Y = y;
    }

    public float X 
    {
        get 
        { 
            return x;
        } 
        set
        {
            x = value;
            right = x + (width / 2);
            left = x - (width / 2);
        }
    }


    public float Y
    {
        get
        {
            return y;
        }
        set
        {
            y = value;
            bottom = y + (height / 2);
            top = y - (height / 2);
        }
    }

    public Vector2 Center
    {
        get
        {
            return new Vector2(X, Y);
        }
        set
        {
            X = value.X;
            Y = value.Y;
        }
    }

    public float Height { get { return height; } }
    public float Width { get { return width; } }

    #region sides
    public float Top
    {
        get
        {
            return top;
        }
    }
    public float Bottom
    {
        get
        {
            return bottom;
        }
    }
    public float Left
    {
        get
        {
            return left;
        }
    }
    public float Right 
    { 
        get 
        {
            return right;
        }
    }
    #endregion

    public ContactType CheckContact(Rect rect) 
    {

        if (rect.Top >= Top && rect.Bottom <= Top && Left <= rect.Right)
            return ContactType.left;

        if (rect.Top >= Top && rect.Bottom <= Top && Right >= rect.Left)
            return ContactType.right;

        if (Left <= rect.Right && Left >= rect.Left && Top <= rect.Top && Top >= rect.Bottom)
            return ContactType.top;

        if (Left <= rect.Right && Left >= rect.Left && Top <= rect.Top && Top >= rect.Bottom)
            return ContactType.bottom;

        return ContactType.none;
    }
    public bool Intersect(Rect rect)
    {
        //if (((Top <= rect.Bottom) && (Top >= rect.Top)) && ((Right <= rect.Right) && (Right >= rect.Left)))

        if (rect.Right < Right && rect.Right > Left) // horisontal intersec
        {
                return true;
        }
            
        return false;
    }
}

public enum ContactType
{
    left, right, top, bottom, none
}


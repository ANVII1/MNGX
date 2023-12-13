﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MNGX.Engine.Core;

namespace MNGX.Engine.Managers;

public class Animation
{
    private readonly Texture2D _texture;
    private readonly List<Rectangle> _sourceRectangles = new();
    private readonly int _frames;
    private Rect collision_rect;
    private int _frame;
    private readonly float _frameTime;
    private float _frameTimeLeft;
    private bool _active = true;
    private float scale;
    public Vector2 center { get; private set; }

    public Animation(Texture2D texture, int framesColumnCount, int framesRowsCount, float frameTime, int currentRow = 1, float scale = 1)
    {
        _texture = texture;
        _frameTime = frameTime;
        _frameTimeLeft = _frameTime;
        _frames = framesColumnCount;
        var frameWidth = _texture.Width / framesColumnCount;
        var frameHeight = _texture.Height / framesRowsCount;

        collision_rect = new Rect(0,0, frameWidth * scale, frameHeight * scale);

        for (int i = 0; i < _frames; i++)
        {
            _sourceRectangles.Add(new Rectangle(i * frameWidth, (currentRow - 1) * frameHeight, frameWidth, frameHeight));
        }
        center = new Vector2(frameWidth / 2 * scale, frameHeight / 2 * scale);
        this.scale = scale;
    }
    public void Stop()
    {
        _active = false;
    }

    public void Start()
    {
        _active = true;
    }

    public void Reset()
    {
        _frame = 0;
        _frameTimeLeft = _frameTime;
    }

    public void Update()
    {
        if (!_active) return;

        _frameTimeLeft -= Globals.TotalSeconds;

        if (_frameTimeLeft <= 0)
        {
            _frameTimeLeft += _frameTime;
            _frame = (_frame + 1) % _frames;

        }
    }

    public void draw(Vector2 pos, float rotation, float layerDepth, SpriteEffects spriteEffects)
    {
        Globals.SpriteBatch.Draw(_texture, pos, _sourceRectangles[_frame], Color.White, rotation, Vector2.Zero, scale, spriteEffects, layerDepth);
    }

    public Rect CollisonRect()
    {
        return collision_rect;
    }

}

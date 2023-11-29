﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MNGX.Engine;
using MNGX.Engine.Core;
using MNGX.Engine.Managers;
using MNGX.Engine.Scenes;
using System;

namespace MNGX
{
    public class TWS : Game
    {
        private GraphicsDeviceManager _graphics;

        public TWS()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.ClientSizeChanged += OnResize;
            Globals.ScreenWidth = _graphics.PreferredBackBufferWidth;
            Globals.ScreenHeight = _graphics.PreferredBackBufferHeight;
        }

        private void OnResize(Object sender, EventArgs e) 
        {
            Globals.ScreenWidth = _graphics.PreferredBackBufferWidth;
            Globals.ScreenHeight = _graphics.PreferredBackBufferHeight;
        }

        // //////// Инициализация
        protected override void Initialize()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.sceneManager = new SceneManager();
            Globals.Content = Content;
            Globals.camera = new Camera();
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            Window.AllowUserResizing = true;
            
            base.Initialize();
        }

        // //////// Загрузка контента
        protected override void LoadContent()
        {

            Globals.sceneManager.addScene(new PlayScene());
        }

        // //////// Обновление
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Globals.Update(gameTime);
            Globals.sceneManager.update();
        }

        // //////// Отрисовка
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            Globals.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend,SamplerState.PointClamp, transformMatrix : Globals.camera.Transform);

            Globals.sceneManager.draw();

            Globals.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
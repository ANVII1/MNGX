using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MNGX.Engine;
using MNGX.Engine.Managers;

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
            
        }

        // //////// Инициализация
        protected override void Initialize()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.sceneManager = new SceneManager();
            Globals.Content = Content;
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,SamplerState.PointClamp);
            Globals.sceneManager.draw();

            Globals.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
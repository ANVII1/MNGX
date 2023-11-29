using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MNGX.Engine.Core;
using MNGX.Engine.Managers;

namespace MNGX.Engine
{
    public static class Globals
    {
        public static float TotalSeconds { get; set; }
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static SceneManager sceneManager { get; set; }
        public static EventManager eventManager { get; set; }
        public static Camera camera { get; set; }

        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }

        public static void Update(GameTime gt)
        {
            TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;
        }
    }
}

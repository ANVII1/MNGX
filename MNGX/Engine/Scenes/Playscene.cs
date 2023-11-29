using MNGX.Engine.Managers;
using MNGX.Engine.models;
using Microsoft.Xna.Framework;
using static MNGX.Engine.Managers.Scene;
using System.Linq;

namespace MNGX.Engine.Scenes;
public class PlayScene : Scene
{
    public PlayScene()
    {
        this.createGameObjects();
    }
    public override void createGameObjects()
    {
        gameObjects.Add(new Hero(new Vector2(300, 300)));
        gameObjects.Add(new Enemy(new Vector2(500, 300)));
        // Добавляем ГГ
        gameObjects.Add(new Room(new Vector2(200, 200)));

    }

    public override void update()
    {
        if (state == states.paused)
            return;
        Globals.camera.Follow(gameObjects[0]);
        foreach (GameObject obj in gameObjects.ToList())
            obj.update();

    }
}
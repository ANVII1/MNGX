using MNGX.Engine.models;
using System;
using System.Collections.Generic;

namespace MNGX.Engine.Managers;

public class SceneManager
{
    private List<Scene> scenes;
    private int active_scene;

    public SceneManager()
    {
        this.scenes = new List<Scene>();
        active_scene = 0;
    }

    public void addScene(Scene scene)
    {
        scenes.Add(scene);
    }

    public void addObjectToActiveScene(GameObject gameObject) 
    {
        scenes[active_scene].addObject(gameObject);
    }

    public void update() 
    {
        try 
        {
            scenes[active_scene].update();
        } 
        catch (ArgumentOutOfRangeException) 
        {
            throw new Exception("Не нинциализировано ни одной сцены");
        }
    }

    public Scene getActiveScene() 
    {
        return scenes[active_scene];
    }

    public void draw()
    {
        try
        {
            scenes[active_scene].draw();
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new Exception("Не нинциализировано ни одной сцены");
        }
    }

}

public abstract class Scene 
{
    public List<GameObject> gameObjects = new List<GameObject>();
    public states state = states.active;

    public abstract void createGameObjects(); // В нём создаём все объекты

    public void addObject(GameObject gameObject) 
    {
        gameObjects.Add(gameObject);
    }

    public virtual void update() 
    {
        if (state == states.paused)
            return;
        foreach (GameObject obj in gameObjects)
            obj.update();
    }
    public virtual void draw()
    {
        foreach (GameObject obj in gameObjects)
            obj.draw();
    }
    public enum states {
        paused,
        active
    }
}
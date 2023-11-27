﻿using MNGX.Engine.models;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

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
    protected List<GameObject> gameObjects = new List<GameObject>();
    public states state = states.active;

    public abstract void createGameObjects(); // В нём создаём все объекты

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

public class PlayScene : Scene
{
    public PlayScene() 
    {
        this.createGameObjects();
    }
    public override void createGameObjects()
    {
        gameObjects.Add(new Enemy(new Vector2(500, 300)));
        // Добавляем ГГ
        gameObjects.Add(new Hero(new Vector2(300, 300)));
        gameObjects.Add(new Room(new Vector2(200,200)));
        

    }
}
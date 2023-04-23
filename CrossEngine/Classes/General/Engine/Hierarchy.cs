using CrossEngine.Classes;
using CrossEngine.Shapes;
using CrossEngine.UI;
using System.Collections.Generic;

namespace CrossEngine
{
    public class Hierarchy
    {
        public List<GameObject> AllGameObjects;
        public List<Line> AllLine;
        public List<Cycle> AllCycles;
        public List<Text> AllTexts;

        public Hierarchy()
        {
            AllGameObjects = new List<GameObject>();
            AllLine = new List<Line>();
            AllCycles = new List<Cycle>();
            AllTexts = new List<Text>();
        }

        public uint RootCount
        {
            get
            {
                return (uint)(AllGameObjects.Count + AllLine.Count + AllCycles.Count + AllTexts.Count);
            }
        }

        public void CreatNewGameObject(GameObject gameobject)
        {
            AllGameObjects.Add(gameobject);
        }
        public GameObject CreatNewGameObject(string tag, Vector2 Position, Vector2 Scale)
        {
            GameObject g = new GameObject();
            g.Tag = tag;
            g.Position = Position;
            g.Scale = Scale;
            AllGameObjects.Add(g);

            return g;
        }
        public GameObject CreatNewGameObject(string name, string tag, Vector2 Position, Vector2 Scale)
        {
            GameObject g = new GameObject();
            g.Name = name;
            g.Tag = tag;
            g.Position = Position;
            g.Scale = Scale;
            AllGameObjects.Add(g);

            return g;
        }

        public static void CreatNewGameObjectFromScene(GameObject gameobject)
        {
            SceneManager.LoadedScene.SceneHierarchy.AllGameObjects.Add(gameobject);
        }
        public static GameObject CreatNewGameObjectFromScene(string tag, Vector2 Position, Vector2 Scale)
        {
            GameObject g = new GameObject();
            g.Tag = tag;
            g.Position = Position;
            g.Scale = Scale;

            SceneManager.LoadedScene.SceneHierarchy.AllGameObjects.Add(g);
            return g;
        }
        public static GameObject CreatNewGameObjectFromScene(string name, string tag, Vector2 Position, Vector2 Scale)
        {
            GameObject g = new GameObject();
            g.Name = name;
            g.Tag = tag;
            g.Position = Position;
            g.Scale = Scale;

            SceneManager.LoadedScene.SceneHierarchy.AllGameObjects.Add(g);
            return g;
        }

        public static uint GetGameObjectIndexInList(GameObject target)
        {
            for (int i = 0; i < SceneManager.LoadedScene.SceneHierarchy.AllGameObjects.Count; i++)
            {
                if (SceneManager.LoadedScene.SceneHierarchy.AllGameObjects[i] == target)
                {
                    return (uint)i;
                }
            }

            Debug.PrintError("GameObject " + target + " inst in that list.");
            return 0;
        }
    }
}

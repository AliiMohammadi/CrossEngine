using System.Drawing;

namespace CrossEngine.Classes
{
    public class Line
    {
        public Color color;
        public Vector2 Position1;
        public Vector2 Position2;

        public Line(Color color,Vector2 Position1, Vector2 Position2)
        {
            this.color = color;
            this.Position1 = Position1;
            this.Position2 = Position2;

            SceneManager.LoadedScene.SceneHierarchy.AllLine.Add(this);
        }

        public void DestroySelf()
        {
            SceneManager.LoadedScene.SceneHierarchy.AllLine.Remove(this);
        }
    }
}

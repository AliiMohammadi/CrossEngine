using System.Drawing;

namespace CrossEngine.Shapes
{
    public class Cycle
    {
        public Color color;

        public Vector2 Position;
        public float Radias = 1;

        public Cycle(Color color, Vector2 Position , float radias)
        {
            this.color = color;
            this.Position = Position;
            Radias = radias;

            SceneManager.LoadedScene.SceneHierarchy.AllCycles.Add(this);
        }

        public void DestroySelf()
        {
            SceneManager.LoadedScene.SceneHierarchy.AllCycles.Remove(this);
        }
    }
}

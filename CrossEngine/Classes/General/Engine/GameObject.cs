
namespace CrossEngine
{
    public class GameObject
    {
        //
        // Summary:
        //     The layer the game object is in. A layer is in the range [0...31].
        public int layer { get; set; }
        //
        // Summary:
        //     Scene that the GameObject is part of.
        public string Name = "Unnamed";
        public string Tag = "Untaget";
        public bool Active = true;
        public Scene scene { get; }

        public Vector2 Position = Vector2.zero;
        public float Rotation = 0;
        public Vector2 Scale = new Vector2(1,1);

        public SpriteRendere SpriteRendere;
        public RigidBody RigidBody;

        bool IsAlive = true;

        public GameObject()
        {

        }
        public GameObject(string name)
        {
            Name = name;
            scene = SceneManager.LoadedScene;

            Hierarchy.CreatNewGameObjectFromScene(this);
        }
        public GameObject(string name,string Tag, Vector2 Position, Vector2 Scale)
        {
            Name = name;
            this.Tag = Tag;
            this.Scale = Scale;
            this.Position = Position;
            scene = SceneManager.LoadedScene;

            Hierarchy.CreatNewGameObjectFromScene(this);
        }
        public GameObject(string Tag, Vector2 Position, Vector2 Scale)
        {
            this.Tag = Tag;
            this.Scale = Scale;
            this.Position = Position;
            scene = SceneManager.LoadedScene;

            Hierarchy.CreatNewGameObjectFromScene(this);
        }

        public void Destroy()
        {
            if (IsAlive)
            {
                SceneManager.LoadedScene.SceneHierarchy.AllGameObjects.Remove(this);
                IsAlive = false;
            }
        }
        public void Translate(Vector2 Direction)
        {
            Position = new Vector2(Position.x + Direction.x , Position.y + Direction.y);
        }
        public void UpdateComponents ()
        {
            if (SpriteRendere != null)
            {
                SpriteRendere.UpdateComponent();
            }
            if (RigidBody != null)
            {
                RigidBody.UpdateComponent();
            }
        }
    }
}

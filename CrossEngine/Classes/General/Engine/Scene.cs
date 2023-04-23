
namespace CrossEngine
{
    public struct Scene
    {
        public Hierarchy SceneHierarchy;

        //
        // Summary:
        //     Returns the name of the scene.
        public string Name;
        //
        // Summary:
        //     Returns the index of the scene in the Build Settings. Always returns -1 if the
        //     scene was loaded through an AssetBundle.
        public int Index
        {
            get
            {
                return SceneManager.GetScene(Name).Index;
            }
        }
        //
        // Summary:
        //     The number of root transforms of this scene.
        public uint RootCount
        {
            get
            {
                return SceneHierarchy.RootCount;
            }
        }

        public Scene(string name)
        {
            Name = name;
            SceneHierarchy = new Hierarchy();
            SceneManager.AllScenes.Add(this);
        }
    }
}

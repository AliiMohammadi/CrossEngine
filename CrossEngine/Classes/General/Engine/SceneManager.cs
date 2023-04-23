using CrossEngine.Classes;
using System.Collections.Generic;

namespace CrossEngine
{
    public class SceneManager
    {
        public static List<Scene> AllScenes = new List<Scene>();
        public static Scene LoadedScene;

        // Summary:
        //     The total number of currently loaded Scenes.
        public static int SceneCount
        {
            get
            {
                return AllScenes.Count;
            }
        }

        public delegate void deli();

        public static event deli SceneLoaded;

        // Summary:
        //     Create an empty new Scene at runtime with the given name.
        //
        // Parameters:
        //   sceneName:
        //     The name of the new Scene. It cannot be empty or null, or same as the name of
        //     the existing Scenes.
        //
        // Returns:
        //     A reference to the new Scene that was created, or an invalid Scene if creation
        //     failed.
        public static Scene CreateScene(string sceneName)
        {
            return new Scene(sceneName);
        }
        //
        // Summary:
        //     Get a Scene struct from a build index.
        //
        // Parameters:
        //   buildIndex:
        //     Build index as shown in the Build Settings window.
        //
        // Returns:
        //     A reference to the Scene, if valid. If not, an invalid Scene is returned.
        public static Scene GetScene(int Index)
        {
            return AllScenes[Index];
        }
        //
        // Summary:
        //     Searches through the Scenes loaded for a Scene with the given name.
        //
        // Parameters:
        //   name:
        //     Name of Scene to find.
        //
        // Returns:
        //     A reference to the Scene, if valid. If not, an invalid Scene is returned.
        public static Scene GetScene(string name)
        {
            foreach (Scene item in AllScenes)
            {
                if (string.Equals(name, item.Name))
                {
                    return item;
                }
            }

            Debug.PrintWarning("Could not find any scene named with : " + name);
            return AllScenes[0];
        }
        public static void LoadScene(int sceneIndex)
        {
            LoadedScene = AllScenes[sceneIndex];
            try
            {
                SceneLoaded();
            }
            catch 
            {
            }

        }
        public static void LoadScene(string sceneName)
        {
            LoadedScene = GetScene(sceneName);
            SceneLoaded();
        }
    }
}

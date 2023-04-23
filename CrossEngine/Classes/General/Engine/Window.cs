using CrossEngine.Classes;
using System.Drawing;
using System.Windows.Forms;

namespace CrossEngine
{
    public class Window
    {
        public static Form Panel;
        public static MainForm mainForm;
        public static bool FullScreen = false;
        public static Vector2 ScreenSize = new Vector2(800, 600);

        public static void Refresh()
        {
            Panel.Text = SceneManager.LoadedScene.Name;
            Panel.Size = new Size((int)ScreenSize.x, (int)ScreenSize.y);
        }
    }
}

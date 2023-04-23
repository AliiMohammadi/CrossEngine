using System;
using System.Windows.Forms;

namespace CrossEngine
{
    class Program 
    {

        [STAThread]
        static void Main()
        {
            Start();
            Console.ReadKey();
        }

        static void Start ()
        {
            SetFormSetings();
            CreatLevels();
            Engine.StartEngine();
        }
        static void SetFormSetings ()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
        static void CreatLevels ()
        {
            SceneManager.CreateScene("unnamedscene");
            SceneManager.LoadScene(0);
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using CrossEngine.Classes;
using System.Diagnostics;

namespace CrossEngine
{
    public class Engine
    {
        public static Assembly EngineAssmbly;
        public static Type[] EngineAssmblyTyps;
        public static float TargetFPS = 120;
        public static sbyte FPS
        {
            get
            {
                double secondsElapsed = (DateTime.Now - _lastCheckTime).TotalSeconds;
                long count = Interlocked.Exchange(ref frameCount, 0);
                double fps = count / secondsElapsed;
                _lastCheckTime = DateTime.Now;
                return (sbyte)fps;
            }
        }

        static long frameCount = 0;
        static object[] ob;
        static int ScriptsCount;

        static Thread UpdateThread;
        static Thread FixedUpdateThread;

        static DateTime _lastCheckTime = DateTime.Now;
        static bool EngineStarted = false;

        static Type[] MainRunnTimeAssmblyTyps;

        public static void StartEngine ()
        {
            if (!EngineStarted)
            {
                try
                {
                    WindowDetailsSet();
                    GetAssmebly();

                    Debug.Print("Runing...");
                    EngineStarted = true;
                    SendMessageToEngineFunctions("Awake");
                    TurrningOnLoops();
                    Application.Run(Window.Panel);
                }
                catch (Exception ex)
                {
                    Debug.PrintError("Error to Run Engine. Exception: " + ex.Message);
                }
            }
            else if(!EngineStarted)
            {
                Debug.PrintWarning("Engine has already started before.");
            }
        }

        static void GetAssmebly()
        {
            EngineAssmbly = Assembly.GetExecutingAssembly();
            EngineAssmblyTyps = EngineAssmbly.GetTypes();
            ScriptsCount = 0;

            foreach (var item in EngineAssmblyTyps)
            {
                try
                {
                    string name = item.GetInterface("Script").Name;

                    if (name != string.Empty)
                    {
                        ScriptsCount++;
                    }
                }
                catch 
                {

                }

            }

            ob = new object[ScriptsCount];
            MainRunnTimeAssmblyTyps = new Type[ScriptsCount];
            int i = 0;

            foreach (var item in EngineAssmblyTyps)
            {
                try
                {
                    string name = item.GetInterface("Script").Name;

                    if (name != string.Empty)
                    {
                        MainRunnTimeAssmblyTyps[i] = item;
                        ob[i] = Activator.CreateInstance(item);
                        i++;
                    }
                }
                catch 
                {

                }
            }
        }
        static void WindowDetailsSet ()
        {
            Window.mainForm = new MainForm();
            Window.Panel = Window.mainForm;
            Window.Refresh();
            Window.Panel.Paint += Rendering.RenderStart;
            //Window.Panel.MouseMove += Input.UpdateMouseMoving;
            Window.mainForm.UIpic.MouseMove += Input.UpdateMouseMoving;
            Window.Panel.KeyDown += Input.RefreshEventPressDown;
            Window.Panel.KeyUp += Input.RefreshEventPressUp;
            Window.mainForm.Focus();
            SceneManager.SceneLoaded += Window.Refresh;
        }
        static void TurrningOnLoops ()
        {
            FixedUpdateThread = new Thread(StartFixedUpdateLoop);
            FixedUpdateThread.Start();

            UpdateThread = new Thread(StartUpdateLoop);
            UpdateThread.Start();
        }
        static void StartFixedUpdateLoop ()
        {
            while (UpdateThread.IsAlive)
            {
                try
                {
                    Thread.Sleep((int)((Time.fixedTime * 1000) * Time.fixedDeltaTime));
                    SendMessageToEngineFunctions("FixedUpdate");
                }
                catch (Exception ex)
                {
                    Debug.PrintError("Error FixedUpdate Loop Engine. Exception: " + ex.Message);
                }
            }
        }
        static void StartUpdateLoop ()
        {
            SendMessageToEngineFunctions("Start");
            Debug.Print("Engine Started.");

            while (UpdateThread.IsAlive)
            {
                try
                {
                    int slee = (int)((1000 / TargetFPS) * Time.deltaTime * Time.timeScale);

                    //Window.Panel.BeginInvoke((MethodInvoker)delegate { Window.Panel.Refresh(); });

                    Window.mainForm.UIpic.BeginInvoke((MethodInvoker)delegate { Window.mainForm.UIpic.Refresh(); });
                    SendMessageToEngineFunctions("Update");

                    Interlocked.Increment(ref frameCount);

                    Thread.Sleep(slee);
                }
                catch (Exception ex) 
                {
                    Debug.PrintError("Error Update Loop Engine. Exception: " + ex.Message);
                }
            }
        }
        static void SendMessageToEngineFunctions(string methodName)
        {
            for (int i = 0; i < ScriptsCount; i++)
            {
                try
                {
                    MainRunnTimeAssmblyTyps[i].GetMethod(methodName).Invoke(ob[i], null);
                }
                catch { }
            }
        }
    }
}

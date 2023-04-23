using CrossEngine.Classes;
using CrossEngine.Shapes;
using System;
using System.Drawing;

namespace CrossEngine
{
    public class Debug 
    {
        public static void Print(object Messgae)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Write("[Log]" + Messgae);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintWarning(object Messgae)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Write("[Warning]"+ Messgae);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintError(object Messgae)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Write("[Error]" + Messgae);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DrawLine(Vector2 Point1, Vector2 Point2,Color color)
        {
            Line l = new Line(color, Point1, Point2);
            SceneManager.LoadedScene.SceneHierarchy.AllLine.Add(l);
        }
        public static void DrawLine (Vector2 Point1 , Vector2 Point2)
        {
            Line l = new Line(Color.White,Point1, Point2);
            SceneManager.LoadedScene.SceneHierarchy.AllLine.Add(l);
        }

        public static void DrawCycle (Vector2 Position , float Radias , Color color)
        {
            Cycle c = new Cycle(color,Position, Radias);
            SceneManager.LoadedScene.SceneHierarchy.AllCycles.Add(c);
        }
        public static void DrawCycle(Vector2 Position, float Radias)
        {
            Cycle c = new Cycle(Color.White, Position, Radias);
            SceneManager.LoadedScene.SceneHierarchy.AllCycles.Add(c);
        }
        public static void DrawCycle(Vector2 Position)
        {
            Cycle c = new Cycle(Color.White, Position, 1);
            SceneManager.LoadedScene.SceneHierarchy.AllCycles.Add(c);
        }

        public static void SayBeep(int frequency,int duration)
        {
            Console.Beep(frequency,duration);
        }
        public static void SayBeep()
        {
            Console.Beep();
        }

        static void Write(object Messgae)
        {
            Console.WriteLine(Messgae);
        }

    }
}

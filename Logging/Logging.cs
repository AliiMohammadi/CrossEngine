using System;
using System.IO;
using System.Text;

namespace Logging
{
    public class Logging
    {
        public string Filename = Environment.CurrentDirectory;

        public void Log (object Message)
        {
            Print("[Log] " + Message);
        }
        public void LogWarning(object Message)
        {
            Print("[Warning] " + Message);
        }
        public void LogError(object Message)
        {
            Print("[Error] " + Message);
        }
        public void DeleteLogFile ()
        {
            File.Delete(Filename);
        }

        void Print(object Message)
        {
            if (!File.Exists(Filename))
            {
                CreatLogFile();
            }
            File.AppendAllText(Filename , Message + "\r\n" , Encoding.UTF8);
        }
        void CreatLogFile ()
        {
            File.WriteAllText(Filename, "test");
            File.WriteAllText(Filename, string.Empty);
        }
    }
}

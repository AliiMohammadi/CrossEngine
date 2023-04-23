using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Reflection;

namespace Test_Console
{
    class Program 
    {
        static void Main(string[] args)
        {
            mainClass mm = new mainClass();
            Console.ReadKey();
        }
        static void ParalleLoops ()
        {
            var timer = new Stopwatch();

            timer.Start();
            Parallel.For(0, 100, i =>
            {
                i = 200;
            });

            timer.Stop();
            print(timer.Elapsed);
            timer.Reset();
        }
        static void CallVoidWithInvoke ()
        {
            var sample = new ReflectionTestClass();
            var sampletype = typeof(ReflectionTestClass);
            var mymethod = sampletype.GetMethod("methodtest");
            mymethod.Invoke(sample, null);
        }
        static void CallingVoidsWithAnInterface ()
        {
            //assmbly from this project
            var assm = Assembly.GetExecutingAssembly();
            var classes = assm.GetTypes();

            foreach (var item in classes)
            {
                try
                {
                    string ins = item.GetInterface("Behavior").Name;

                    if (ins != string.Empty)
                    {

                        var ty = Activator.CreateInstance(item);
                        SampleClass s = ty as SampleClass;
                        s.isac = false;
                        if (s.isac)
                        {
                            item.GetMethod("Start").Invoke(ty, null);
                        }
                    }
                }
                catch
                {

                }
            }
        }

        static void print(object Message)
        {
            Console.WriteLine(Message);
        }
    }

    public class ReflectionTestClass : SampleClass
    {

        public void methodtest ()
        {
            //Console.WriteLine("Hello world.");
        }

        public void Start ()
        {
            Console.WriteLine("Hello world.called from interface.");
        }
    }
    public class ReflectionTestClass2 : SampleClass
    {

        public void Start()
        {
            Console.WriteLine("Hello world.called from interface.");
        }
    }

    public class SampleClass : Behavior
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public bool isac { get; set; }
    }
    public interface Behavior
    {

    }
    public abstract class Abst
    {
        int ss = 10;
        public Abst()
        {
            Start();
        }
        public virtual void Start()
        {
            Console.WriteLine("Hello from virtual Function Start.");
        }
        public virtual void Update()
        {
            Console.WriteLine("Hello from virtual Function Update.");
        }
    }
    public class mainClass : Abst
    {
        public override void Start()
        {
            base.Update();
        }
    }
}

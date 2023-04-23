using System;
using System.Diagnostics;
using System.Threading;

namespace CrossEngine
{
    public class Time
    {
        //
        // Summary:
        //     The scale at which the time is passing. This can be used for slow motion effects.
        public static float timeScale = 1;
        //
        // Summary:
        //     The interval in seconds at which physics and other fixed frame rate updates (like
        //     MonoBehaviour's MonoBehaviour.FixedUpdate) are performed.
        public static float fixedDeltaTime = 1;
        //
        // Summary:
        //     The time the latest MonoBehaviour.FixedUpdate has started (Read Only). This is
        //     the time in seconds since the start of the game.
        public static float fixedTime = 0.001f;
        //
        // Summary:
        //     The time in seconds it took to complete the last frame (Read Only).
        public static float deltaTime = 1;
        //
        // Summary:
        //     The time at the beginning of this frame (Read Only). This is the time in seconds
        //     since the start of the game.
        public static float time = 1;

        public static void WaitForSecond(float Time, Delegate method)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
            {
                Thread.Sleep((int)(Time * 1000));
                Debug.Print("Hello");
            }));
        }
    }
}

using System;
using System.Drawing;

namespace CrossEngine
{
    /// <summary>
    ///   <para>Representation of RGBA colors.</para>
    /// </summary>
    public struct ColorMath 
    {
        /// <summary>
        ///   <para>Linearly interpolates between colors a and b by t.</para>
        /// </summary>
        /// <param name="a">Color a</param>
        /// <param name="b">Color b</param>
        /// <param name="t">Float for combining a and b</param>
        public static Color Lerp(Color a, Color b, float t)
        {
            t = Mathf.Clamp01(t);
            return Color.FromArgb((int)(a.R + (b.R - a.R) * t), (int)(a.G + (b.G - a.G) * t), (int)(a.B + (b.B - a.B) * t), (int)(a.A + (b.A - a.A) * t));
        }

    }
}

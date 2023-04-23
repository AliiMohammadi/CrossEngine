using System.Windows.Input;

namespace CrossEngine
{
    public class Input
    {
        //تعداد این بولین ها باید رقم اخر کلید اخر کلاس کی کود باشه 
        static bool[] keys = new bool[329];
        public static Vector2 MousePosition = Vector2.zero;

        //
        // Summary:
        //     Returns true the first frame the user hits any key or mouse button. (Read Only)
        public static bool anyKeyDown ()
        {
            foreach (bool item in keys)
            {
                if (item)
                {
                    return true;
                }
            }
            return false;
        }
        //
        // Summary:
        //     Returns true during the frame the user starts pressing down the key identified
        //     by the key KeyCode enum parameter.
        //
        // Parameters:
        //   key:
        public static bool GetKeyDown(KeyCode key)
        {
            return keys[(int)key];
        }
        //
        // Summary:
        //     Returns true during the frame the user releases the key identified by the key
        //     KeyCode enum parameter.
        //
        // Parameters:
        //   key:
        public static bool GetKeyUp(KeyCode key)
        {
            return keys[(int)key];
        }
        //
        // Summary:
        //     Returns true during the frame the user pressed the given mouse button.
        //
        // Parameters:
        //   button:
        public static bool GetMouseButtonDown(int button)
        {
            switch (button)
            {
                case 0:
                    if (Mouse.LeftButton == MouseButtonState.Pressed)
                    {
                        return true;
                    }
                    break;

                case 1:
                    if (Mouse.RightButton == MouseButtonState.Pressed)
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }

            return false;
        }
        //
        // Summary:
        //     Returns true during the frame the user releases the given mouse button.
        //
        // Parameters:
        //   button:
        public static bool GetMouseButtonUp(int button)
        {
            switch (button)
            {
                case 0:
                    if (Mouse.LeftButton == MouseButtonState.Released)
                    {
                        return true;
                    }
                    break;

                case 1:
                    if (Mouse.RightButton == MouseButtonState.Released)
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }

            return false;
        }

        public static void UpdateMouseMoving(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Vector2 screenposition = WorldSpace.ConvertMeterToPixelUnit(Camera.Position);

            uint halfScreenWidth = (uint)(Window.Panel.Size.Width / 2);
            uint halfScreenHeight = (uint)(Window.Panel.Size.Height / 2);

            float x = ((-screenposition.x)) + halfScreenWidth;
            float y = ((screenposition.y)) + halfScreenHeight;

            Vector2 nepo = new Vector2(e.X - x, -(e.Y - y));
            MousePosition = WorldSpace.ConvertPixelToMeterUnit(nepo);
        } 
        public static void RefreshEventPressDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            keys[(int)e.KeyCode] = true;
        }
        public static void RefreshEventPressUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            keys[(int)e.KeyCode] = false;
        }
    }
}

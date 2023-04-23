using System.Drawing;

namespace CrossEngine
{
    public class Camera
    {
        public static Color BGcolore = Color.SkyBlue;
        public static Vector2 Position = Vector2.zero;

        public static float Scale = 1f;
        public static float Angle = 0;

        public Vector2 CameraSize = Vector2.zero;

        static void SetPosition()
        {
            Vector2 pos = WorldSpace.ConvertMeterToPixelUnit(Position);

            uint halfScreenWidth = (uint)(Window.Panel.Size.Width / 2);
            uint halfScreenHeight = (uint)(Window.Panel.Size.Height / 2);

            float x = ((-pos.x) * Scale) + halfScreenWidth;
            float y = ((pos.y) * Scale) + halfScreenHeight;

            Rendering.WorldGraf.TranslateTransform(x, y);
        }
        static void SetScale()
        {
            Rendering.WorldGraf.ScaleTransform(Scale, Scale);
        }
        static void SetAngle()
        {
            Rendering.WorldGraf.RotateTransform(Angle);
        }

        public static bool IsVisible(GameObject Target)
        {

            return false;
        }

        public static void Refresh()
        {
            //FollowTarget(Graf,TargetToFollow);
            SetPosition();
            SetScale();
            SetAngle();
        }
    }
}

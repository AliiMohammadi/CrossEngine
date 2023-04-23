
namespace CrossEngine
{
    public class WorldSpace
    {
        public static float PixelMultiply = 10.00f; //هر متر انقدر پیسل در دنیای بازی هست

        public static Vector2 ConvertPixelToMeterUnit(Vector2 WindowPosition)
        {
            return new Vector2(WindowPosition.x / PixelMultiply, WindowPosition.y / PixelMultiply); ;
        }
        public static Vector2 ConvertMeterToPixelUnit(Vector2 GameWordPosition)
        {
            return new Vector2(GameWordPosition.x * PixelMultiply, GameWordPosition.y * PixelMultiply); ;
        }
        public static float ConvertMeterToPixelUnit(float Number)
        {
            return (PixelMultiply * Number);
        }
    }
}

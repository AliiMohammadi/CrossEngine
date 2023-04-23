
namespace CrossEngine
{
    public class Transform
    {
        public Vector2 Position = Vector2.zero;
        public float Rotation = 0;
        public Vector2 Scale = new Vector2(1, 1);

        public float LookAt (Vector2 point)
        {

            float X = Position.x - point.x;
            float Y = Position.y - point.y;

            Vector2 vec = new Vector2(X, Y);
            vec.Normalize();

            float tt = -(Mathf.Atan2(vec.x, vec.y) * (180 / Mathf.PI) + 90);

            return tt;
        }
        public void Translate(Vector2 Direction)
        {
            Position = new Vector2(Position.x + Direction.x, Position.y + Direction.y);
        }
        public void Rotate(float Direction)
        {
            Rotation = Rotation + Direction;
        }
    }
}

using System;

namespace CrossEngine
{
    public struct Vector2
    {
        /// <summary>
        ///   <para>X component of the vector.</para>
        /// </summary>
        public float x;
        /// <summary>
        ///   <para>Y component of the vector.</para>
        /// </summary>
        public float y;

        static readonly Vector2 zeroVector = new Vector2(0.0f, 0.0f);
        static readonly Vector2 oneVector = new Vector2(1f, 1f);
        static readonly Vector2 upVector = new Vector2(0.0f, 1f);
        static readonly Vector2 downVector = new Vector2(0.0f, -1f);
        static readonly Vector2 leftVector = new Vector2(-1f, 0.0f);
        static readonly Vector2 rightVector = new Vector2(1f, 0.0f);

        public Vector2(float x , float y)
        {
            this.x = x;
            this.y = y;
        }

        public static float Distance (Vector2 Point1 , Vector2 Point2)
        {
            float x = Math.Abs((Point1.x - Point2.x));
            float y = Math.Abs((Point1.y - Point2.y));
            float fi = (float)(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));

            return fi;
        }
        public static float Distance (GameObject object1, GameObject object2)
        {
            return Distance(object1.Position, object2.Position);
        }
        public static float SinOfTowPoints (Vector2 Point1, Vector2 Point2)
        {
            float x = (Point2.x - Point1.x);
            float y = (Point2.y - Point1.y);
            float C = (float)(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));

            return (y / C);
        }
        public static float CosOfTowPoints(Vector2 Point1, Vector2 Point2)
        {
            float x = (Point2.x - Point1.x);
            float y = (Point2.y - Point1.y);
            float C = (float)(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));

            return (x / C);
        }
        public static float AngleToLook(Vector2 Position1, Vector2 Position2)
        {

            float X = Position1.x - Position2.x;
            float Y = Position1.y - Position2.y;

            Vector2 vec = new Vector2(X, Y);
            vec.Normalize();

            float tt = -(Mathf.Atan2(vec.x, vec.y) * (180 / Mathf.PI) + 90);

            return tt;
        }


        /// <summary>
        ///   <para>Set x and y components of an existing Vector2.</para>
        /// </summary>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        public void Set(float newX, float newY)
        {
            this.x = newX;
            this.y = newY;
        }

        /// <summary>
        ///   <para>Linearly interpolates between vectors a and b by t.</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            t = Mathf.Clamp01(t);
            return new Vector2(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t);
        }

        /// <summary>
        ///   <para>Linearly interpolates between vectors a and b by t.</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, float t) => new Vector2(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t);

        /// <summary>
        ///   <para>Moves a point current towards target.</para>
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDistanceDelta"></param>
        public static Vector2 MoveTowards(
          Vector2 current,
          Vector2 target,
          float maxDistanceDelta)
        {
            Vector2 vector2 = target - current;
            float magnitude = vector2.magnitude;
            return (double)magnitude <= (double)maxDistanceDelta || (double)magnitude == 0.0 ? target : current + vector2 / magnitude * maxDistanceDelta;
        }

        /// <summary>
        ///   <para>Multiplies two vectors component-wise.</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static Vector2 Scale(Vector2 a, Vector2 b) => new Vector2(a.x * b.x, a.y * b.y);

        /// <summary>
        ///   <para>Multiplies every component of this vector by the same component of scale.</para>
        /// </summary>
        /// <param name="scale"></param>
        public void Scale(Vector2 scale)
        {
            this.x *= scale.x;
            this.y *= scale.y;
        }

        /// <summary>
        ///   <para>Makes this vector have a magnitude of 1.</para>
        /// </summary>
        public void Normalize()
        {
            float magnitude = this.magnitude;
            if ((double)magnitude > 9.99999974737875E-06)
                this = this / magnitude;
            else
                this = Vector2.zero;
        }

        /// <summary>
        ///   <para>Returns this vector with a magnitude of 1 (Read Only).</para>
        /// </summary>
        public Vector2 normalized
        {
            get
            {
                Vector2 vector2 = new Vector2(this.x, this.y);
                vector2.Normalize();
                return vector2;
            }
        }

        /// <summary>
        ///   <para>Dot Product of two vectors.</para>
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        public static float Dot(Vector2 lhs, Vector2 rhs) => (float)((double)lhs.x * (double)rhs.x + (double)lhs.y * (double)rhs.y);
        /// <summary>
        ///   <para>Returns the length of this vector (Read Only).</para>
        /// </summary>
        public float magnitude => Mathf.Sqrt((float)((double)this.x * (double)this.x + (double)this.y * (double)this.y));
        /// <summary>
        ///   <para>Returns the squared length of this vector (Read Only).</para>
        /// </summary>
        public float sqrMagnitude => (float)((double)this.x * (double)this.x + (double)this.y * (double)this.y);

        /// <summary>
        ///   <para>Shorthand for writing Vector2(0, 0).</para>
        /// </summary>
        public static Vector2 zero => zeroVector;

        /// <summary>
        ///   <para>Shorthand for writing Vector2(1, 1).</para>
        /// </summary>
        public static Vector2 one => oneVector;

        /// <summary>
        ///   <para>Shorthand for writing Vector2(0, 1).</para>
        /// </summary>
        public static Vector2 up => upVector;

        /// <summary>
        ///   <para>Shorthand for writing Vector2(0, -1).</para>
        /// </summary>
        public static Vector2 down => downVector;

        /// <summary>
        ///   <para>Shorthand for writing Vector2(-1, 0).</para>
        /// </summary>
        public static Vector2 left => leftVector;

        /// <summary>
        ///   <para>Shorthand for writing Vector2(1, 0).</para>
        /// </summary>
        public static Vector2 right => rightVector;


        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);

        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);

        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.x * b.x, a.y * b.y);

        public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a.x / b.x, a.y / b.y);

        public static Vector2 operator -(Vector2 a) => new Vector2(-a.x, -a.y);

        public static Vector2 operator *(Vector2 a, float d) => new Vector2(a.x * d, a.y * d);

        public static Vector2 operator *(float d, Vector2 a) => new Vector2(a.x * d, a.y * d);

        public static Vector2 operator /(Vector2 a, float d) => new Vector2(a.x / d, a.y / d);

        public static bool operator ==(Vector2 lhs, Vector2 rhs) => (double)(lhs - rhs).sqrMagnitude < 9.99999943962493E-11;

        public static bool operator !=(Vector2 lhs, Vector2 rhs) => !(lhs == rhs);
    }
}

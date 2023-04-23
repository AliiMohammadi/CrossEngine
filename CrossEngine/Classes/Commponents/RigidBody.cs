using System;

namespace CrossEngine
{
    public class RigidBody : Behaviour
    {
        public GameObject Target;

        public bool EnableGravity = false;
        public float GravityScale = 1;
        public float Mass = 1;
        public float AirDragg = 0.1f;
        public Vector2 velocity = Vector2.zero;

        uint targetIndex;

        public bool LockDownForces;
        public bool LockUpForces;
        public bool LockLeftForces;
        public bool LockRightForces;

        public RigidBody(GameObject Target)
        {
            this.Target = Target;
            targetIndex = Hierarchy.GetGameObjectIndexInList(this.Target);
        }

        void SetVelocityEffect ()
        {
            if (LockDownForces)
            {
                if (velocity.y < 0.000f)
                {
                    velocity.y = 0;
                }
            }
            if (LockUpForces)
            {
                if (velocity.y > 0.000f)
                {
                    velocity.y = 0;
                }
            }
            if (LockLeftForces)
            {
                if (velocity.x < 0.000f)
                {
                    velocity.x = 0;
                }
            }
            if (LockRightForces)
            {
                if (velocity.x > 0.000f)
                {
                    velocity.x = 0;
                }
            }

            Vector2 FinalVelocity = ConvertVelocityInPixelUnit(velocity);
            Target.Position = new Vector2(Target.Position.x + FinalVelocity.x, Target.Position.y + FinalVelocity.y);
        }
        void SetGravityEffect()
        {
            if (EnableGravity)
            {
                AddForce(new Vector2(0, ((Physics.Gravity * GravityScale) * Mass)));
            }
        }
        void ApplyAirDraggEffect()
        {
            float X = 0;
            float Y = 0;

            if (velocity.x > 0)
            {
                X = velocity.x - AirDragg;
            }
            else if (velocity.x < 0)
            {
                X = velocity.x + AirDragg;
            }
            if (velocity.y > 0)
            {
                Y = velocity.y - AirDragg;
            }
            else if (velocity.y < 0)
            {
                Y = velocity.y + AirDragg;
            }

            velocity = new Vector2(X,Y);
        }
        void ZeroCondition()
        {
            if (Math.Abs(velocity.x) < 0.011f)
            {
                velocity = new Vector2(0, velocity.y);
            }
            if (Math.Abs(velocity.y) < 0.011f)
            {
                velocity = new Vector2(velocity.x, 0);
            }
        }

        public void UpdateComponent ()
        {
            Target = SceneManager.LoadedScene.SceneHierarchy.AllGameObjects[(int)targetIndex];

            SetGravityEffect();
            SetVelocityEffect();
            ApplyAirDraggEffect();
            ZeroCondition();
        }
        public void AddForce(Vector2 Direction)
        {
            velocity = new Vector2(velocity.x + Direction.x, velocity.y + Direction.y);
        }
        public void AddForce(float Xdirection, float Ydirection)
        {
            AddForce(new Vector2(Xdirection, Ydirection));
        }

        public static Vector2 ConvertVelocityInPixelUnit(Vector2 Velocity)
        {
            float m = (WorldSpace.PixelMultiply / Engine.TargetFPS);

            float X = m * Velocity.x;
            float Y = m * Velocity.y;

            return new Vector2(X, Y);
        }
    }
}

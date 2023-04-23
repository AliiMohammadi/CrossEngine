using System;

namespace CrossEngine.Classes.Commponents
{
    public class Collision 
    {
        public class Box 
        {
            public GameObject target;
            public Vector2 CollitionScale = new Vector2(1,1);
            public Vector2 Position = Vector2.zero;

            uint targetindex;

            public Box (GameObject Target)
            {
                target = Target;
                targetindex =   Hierarchy.GetGameObjectIndexInList(this.target);
            }
            public Box (GameObject Target , Vector2 Scale)
            {
                target = Target;
                CollitionScale = Scale;
                targetindex = Hierarchy.GetGameObjectIndexInList(this.target);
            }
            public Box (GameObject Target, Vector2 scale , Vector2 Position)
            {
                target = Target;
                CollitionScale = scale;
                this.Position = Position;
                targetindex = Hierarchy.GetGameObjectIndexInList(this.target);
            }

            public bool IsColliding(Vector2 Position2, Vector2 ColitionSize2)
            {
                Vector2 Tpos = target.Position;
                Vector2 TSpriteSize = target.SpriteRendere.SpriteSize;

                Vector2 CollitionSize = new Vector2(TSpriteSize.x * CollitionScale.x , TSpriteSize.x * CollitionScale.y);

                CollitionSize = WorldSpace.ConvertPixelToMeterUnit(CollitionSize);
                ColitionSize2 = WorldSpace.ConvertPixelToMeterUnit(ColitionSize2);

                TSpriteSize = WorldSpace.ConvertPixelToMeterUnit(TSpriteSize);

                float Xdiscord = ((TSpriteSize.x) - (CollitionSize.x));
                float Ydiscord = ((TSpriteSize.y) - (CollitionSize.y));

                if ((Tpos.x + Xdiscord) < Position2.x + ColitionSize2.x
                 && (Tpos.x + Xdiscord /2) + CollitionSize.x > Position2.x
                 && (Tpos.y + Ydiscord /2) < Position2.y + ColitionSize2.y
                 && (Tpos.y + Ydiscord /2) + CollitionSize.y > Position2.y)
                {
                    return true;
                }

                //if ((Tpos.x + Xdiscord) < Position2.x + ColitionSize2.x
                // && (Tpos.x - Xdiscord) + target.Scale.x > Position2.x
                // && (Tpos.y + Ydiscord) < Position2.y + ColitionSize2.y
                // && (Tpos.y - Ydiscord) + target.Scale.y > Position2.y)
                //{
                //    return true;
                //}

                return false;
            }
            public bool IsColliding(GameObject ObjectB)
            {
                Vector2 Bpos = ObjectB.Position;
                Vector2 BSca = ObjectB.SpriteRendere.SpriteSize;

                return IsColliding( Bpos, BSca);
            }
            public bool IsColliding(string Tag)
            {
                foreach (GameObject ob in SceneManager.LoadedScene.SceneHierarchy.AllGameObjects)
                {
                    if (string.Equals(ob.Tag, Tag))
                    {
                        if (IsColliding(ob))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            public void CollidingWith (Vector2 Position2, Vector2 ColitionSize2)
            {
                target = SceneManager.LoadedScene.SceneHierarchy.AllGameObjects[(int)targetindex];

                if (IsColliding(Position2, ColitionSize2))
                {
                    ColitionSize2 = WorldSpace.ConvertPixelToMeterUnit(ColitionSize2);

                    Vector2 targetpos = target.Position;
                    Vector2 targetsca = target.SpriteRendere.SpriteSize;

                    float SinMax = 
                    Vector2.SinOfTowPoints(Position2, new Vector2(Position2.x + (ColitionSize2.x / 2), Position2.y + (ColitionSize2.y / 2)));
                    float CosMax = 
                    Vector2.CosOfTowPoints(Position2, new Vector2(Position2.x + (ColitionSize2.x / 2), Position2.y + (ColitionSize2.y / 2)));

                    float Sin = Vector2.SinOfTowPoints(Position2, targetpos);
                    float Cos = Vector2.CosOfTowPoints(Position2, targetpos);
                    
                    if (Math.Abs(Cos) > Math.Abs(CosMax))
                    {
                        if (Cos >= 0.000f && Math.Abs(Sin) < Math.Abs(SinMax))
                        {
                            target.RigidBody.LockLeftForces = true;
                        }
                    }
                    if (Math.Abs(Cos) > Math.Abs(CosMax))
                    {
                        if (Cos <= 0.000f && Math.Abs(Sin) < Math.Abs(SinMax))
                        {
                            target.RigidBody.LockRightForces = true;
                        }
                    }

                    if (Math.Abs(Sin) > Math.Abs(SinMax))
                    {
                        if (Sin >= 0.000f && Math.Abs(Cos) < Math.Abs(CosMax))
                        {
                            target.RigidBody.LockDownForces = true;
                        }
                    }
                    if (Math.Abs(Sin) > Math.Abs(SinMax))
                    {
                        if (Sin <= 0.000f && Math.Abs(Cos) < Math.Abs(CosMax))
                        {
                            target.RigidBody.LockUpForces = true;
                        }
                    }
                }
                else
                {
                    target.RigidBody.LockUpForces = false;
                    target.RigidBody.LockDownForces = false;
                    target.RigidBody.LockLeftForces = false;
                    target.RigidBody.LockRightForces = false;
                }
            }
            public void CollidingWith(GameObject ObjectB)
            {
                Vector2 Bpos = ObjectB.Position;
                Vector2 BSca = ObjectB.SpriteRendere.SpriteSize;

                CollidingWith(Bpos, BSca);
            }
            public void CollidingWith(string Tag)
            {
                foreach (GameObject ob in SceneManager.LoadedScene.SceneHierarchy.AllGameObjects)
                {
                    if (string.Equals(ob.Tag, Tag))
                    {
                        CollidingWith(ob);
                    }
                }
            }

            public static bool IsColliding(Vector2 Position1 , Vector2 ColitionSize1, Vector2 Position2, Vector2 ColitionSize2)
            {
                if (Position1.x < Position2.x + ColitionSize2.x
                 && Position1.x + ColitionSize1.x > Position2.x
                 && Position1.y < Position2.y + ColitionSize2.y
                 && Position1.y + ColitionSize1.y > Position2.y)
                {
                    return true;
                }

                return false;
            }
            public static bool IsColliding(GameObject ObjectA, GameObject ObjectB)
            {
                Vector2 Apos = ObjectA.Position;
                Vector2 Bpos = ObjectB.Position;

                Vector2 ASca = ObjectA.Scale;
                Vector2 BSca = ObjectB.Scale;

                return IsColliding(Apos, ASca, Bpos, BSca);
            }
            public static bool IsColliding(GameObject ObjectA, string Tag)
            {
                foreach (GameObject ob in SceneManager.LoadedScene.SceneHierarchy.AllGameObjects)
                {
                    if (string.Equals(ob.Tag, Tag))
                    {
                        if (IsColliding(ObjectA, ob))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            public static bool IsCollidingHorizontaly(Vector2 Position1, Vector2 ColitionSize1, Vector2 Position2, Vector2 ColitionSize2)
            {
                return (((Position1.y + (ColitionSize1.y * 2)) >= (Position2.y + ColitionSize2.y))
                && ((Position1.y - (ColitionSize1.y / 2)) <= (Position2.y - ColitionSize2.y))
                && (Position1.x) <= (Position2.x + ColitionSize2.x)
                && (Position1.x) >= (Position2.x - ColitionSize2.x));
            }
            public static bool IsCollidingHorizontaly(GameObject ObjectA, GameObject ObjectB)
            {
                Vector2 Apos = ObjectA.Position;
                Vector2 Bpos = ObjectB.Position;

                Vector2 ASca = ObjectA.Scale;
                Vector2 BSca = ObjectB.Scale;

                return IsCollidingHorizontaly(Apos,ASca,Bpos,BSca);
            }
            public static bool IsCollidingHorizontaly(GameObject ObjectA, string Tag)
            {
                foreach (GameObject ob in SceneManager.LoadedScene.SceneHierarchy.AllGameObjects)
                {
                    if (string.Equals(ob.Tag, Tag))
                    {
                        if (IsCollidingHorizontaly(ObjectA, ob))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            public static bool IsCollidingVeticaly(Vector2 Position1, Vector2 ColitionSize1, Vector2 Position2, Vector2 ColitionSize2)
            {
                return (((Position1.y + (ColitionSize1.y * 2)) >= (Position2.y + ColitionSize2.y))
                && ((Position1.y - (ColitionSize1.y / 2)) <= (Position2.y - ColitionSize2.y))
                && (Position1.x) <= (Position2.x + ColitionSize2.x)
                && (Position1.x) >= (Position2.x - ColitionSize2.x));
            }
            public static bool IsCollidingVeticaly(GameObject ObjectA, GameObject ObjectB)
            {
                Vector2 Apos = ObjectA.Position;
                Vector2 Bpos = ObjectB.Position;

                Vector2 ASca = ObjectA.Scale;
                Vector2 BSca = ObjectB.Scale;

                return IsColliding(Apos,ASca,Bpos,BSca);
            }
            public static bool IsCollidingVeticaly(GameObject ObjectA, string Tag)
            {
                foreach (GameObject ob in SceneManager.LoadedScene.SceneHierarchy.AllGameObjects)
                {
                    if (string.Equals(ob.Tag, Tag))
                    {
                        if (IsCollidingVeticaly(ObjectA, ob))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        public class Circle
        {
            public static bool IsColliding(Vector2 Position1,float Radian1, Vector2 Position2, float Radian2)
            {
                float dx = Position1.x - Position2.x;
                float dy = Position1.y - Position2.y;

                float distance = (float)Math.Sqrt(dx * dx + dy * dy);

                if (distance < Radian1 + Radian2)
                {
                    return true;
                }

                return false;
            }
            public static bool IsColliding(GameObject ObjectA, GameObject ObjectB)
            {
                Vector2 Apos = ObjectA.Position;
                Vector2 Bpos = ObjectB.Position;

                Vector2 ASca = ObjectA.Scale;
                Vector2 BSca = ObjectB.Scale;

                float Rad1 = Math.Min(ASca.x, ASca.y);
                float Rad2 = Math.Min(BSca.x, BSca.y);

                return IsColliding(Apos, Rad1,Bpos,Rad2);
            }
            public static bool IsColliding(GameObject ObjectA, string Tag)
            {
                foreach (GameObject ob in SceneManager.LoadedScene.SceneHierarchy.AllGameObjects)
                {
                    if (string.Equals(ob.Tag, Tag))
                    {
                        if (IsColliding(ObjectA, ob))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}

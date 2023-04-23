using CrossEngine.Classes.Commponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossEngine.Classes.My_Game
{
    class Enemi : Script
    {
        GameObject enemi;
        RigidBody rigid;

        public void Awake()
        {
            enemi = new GameObject("enemi", new Vector2(0 , 0), new Vector2(2f, 2f));
            rigid = new RigidBody(enemi);
            enemi.SpriteRendere = new SpriteRendere(enemi, "idel.png", 1);
            enemi.RigidBody = rigid;
        }
        public void Update()
        {
            enemi.Rotation = Vector2.AngleToLook(enemi.Position, PlayerScript.pos);
        }
    }
}

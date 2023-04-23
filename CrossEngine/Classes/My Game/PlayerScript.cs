using CrossEngine;
using CrossEngine.Classes.Commponents;
using CrossEngine.Properties;
using CrossEngine.UI;

public class PlayerScript : Script
{
    GameObject Player;
    RigidBody rigid;
    Collision.Box PlayerBoxCollider;
    Text FPStext = new Text(new Vector2(-40, 30), "FPS: " + Engine.FPS);
    public static Vector2 pos;

    public void Awake()
    {
        Player = new GameObject("player", new Vector2(1, 1), new Vector2(2f, 2f));
        rigid = new RigidBody(Player);
        PlayerBoxCollider = new Collision.Box(Player, new Vector2(1f, 1f));
        Player.SpriteRendere = new SpriteRendere(Player, "idel.png", 1);
        Player.RigidBody = rigid;
        //SoundSystem.Play(@"D:\Developing\2DGraphicEngine\2DGraphicEngine\bin\Debug\Asset\Audio\02. M.O.O.N. - Hydrogen.mp3",100);
        //GameObjects[2].SpriteRendere = new SpriteRendere(GameObjects[2], "Cube.png", 2);
    }
    public void FixedUpdate()
    {
        Camera.Position = Vector2.Lerp(Camera.Position, Player.Position, 0.15f);

        PlayerMove();
        LookAtt();
    }
    public void Update()
    {
        FPStext.text = "FPS: " + Engine.FPS;
    }

    float Speed = 1f;
    void PlayerMove()
    {


        if (Input.GetKeyDown(KeyCode.D))
        {
            //GameObjects[0].Translate(new Vector2(Speed, 0));
            //Player.Scale = new Vector2(0.5f, Player.Scale.y);
            Player.Translate(new Vector2(Speed, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //GameObjects[0].Translate(new Vector2(-Speed, 0));
            //Player.Scale = new Vector2(-0.5f, Player.Scale.y);
            Player.Translate(new Vector2(-Speed, 0));
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Player.Translate(new Vector2(0, Speed));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Player.Translate(new Vector2(0, -Speed));
        }

        pos = Player.Position;
    }
    void LookAtt()
    {
        Player.Rotation = Vector2.AngleToLook(Player.Position,Input.MousePosition);
    }
}

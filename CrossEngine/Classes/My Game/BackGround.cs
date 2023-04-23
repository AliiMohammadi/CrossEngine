using CrossEngine;

public class BackGround 
{
    public static GameObject[] GameObjects =
    {
           new GameObject("back ground", new Vector2(0, 0), new Vector2(1f, 1f)),
           new GameObject("Block", new Vector2(0, -10), new Vector2(1f, 1f)),
    };

    public void Start()
    {
        GameObjects[1].SpriteRendere = new SpriteRendere(GameObjects[1], "Back ground.png", 3);
    }
}

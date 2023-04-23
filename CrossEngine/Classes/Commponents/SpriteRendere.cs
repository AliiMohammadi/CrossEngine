using System;
using System.Drawing;

namespace CrossEngine
{
    public class SpriteRendere : Behaviour
    {
        uint TargetIndex;
        public GameObject target;
        public Image image;
        public int OderLayer = 0;
        public Vector2 SpriteSize;

        public bool FlipX = false;

        float lastx;

        public SpriteRendere(GameObject Target, string ImageName,int oderlayer)
        {
            target = Target;
            TargetIndex = Hierarchy.GetGameObjectIndexInList(target);
            OderLayer = oderlayer;

            image = Image.FromFile($"Asset/ArtWork/{ImageName}");
            SpriteSize = new Vector2(image.Width, image.Height);

            Bitmap btm = new Bitmap(image, (int)SpriteSize.x, (int)SpriteSize.y);

            image = btm;
            lastx = target.Scale.x;

            if (lastx < 0.00f)
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
        }

        public void UpdateComponent()
        {
            target = SceneManager.LoadedScene.SceneHierarchy.AllGameObjects[(int)TargetIndex];
            Vector2 tagetScale = target.Scale;

            if (tagetScale.x < 0.00f)
            {
                if (lastx > 0.00f)
                {
                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
                lastx = tagetScale.x;
                tagetScale = new Vector2(Math.Abs(tagetScale.x), tagetScale.y);
            }
            else if (tagetScale.x > 0.00f)
            {
                if (lastx < 0.00f)
                {
                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
                lastx = tagetScale.x;
            }

            float Width = image.Width * tagetScale.x;
            float Height = image.Height * tagetScale.y;

            SpriteSize = new Vector2(Width, Height);

        }
    }
}

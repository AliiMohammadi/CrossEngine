using System.Drawing;

namespace CrossEngine.UI
{
    public class Text
    {
        public Vector2 RecPosition = Vector2.zero;
        public Vector2 Scale = new Vector2(1,1);
        public string text = string.Empty;
        public Font font;
        public Color color = Color.Black;
        public uint size = 24;
        public FontStyle fontstyle;

        public Text(Vector2 recposition, Vector2 scale, string text, Font font, Color color, uint size,FontStyle fonts)
        {
            RecPosition = recposition;
            Scale = scale;
            this.text = text;
            this.font = font;
            this.color = color;
            this.size = size;
            fontstyle = fonts;

            SceneManager.LoadedScene.SceneHierarchy.AllTexts.Add(this);
        }

        public Text(Vector2 recposition , Vector2 scale , string text , Font font , Color color , uint size)
        {
            RecPosition = recposition;
            Scale = scale;
            this.text = text;
            this.font = font;
            this.color = color;
            this.size = size;

            SceneManager.LoadedScene.SceneHierarchy.AllTexts.Add(this);
        }
        public Text(Vector2 recposition, Vector2 scale, string text, Font font, Color color)
        {
            RecPosition = recposition;
            Scale = scale;
            this.text = text;
            this.font = font;
            this.color = color;
            SceneManager.LoadedScene.SceneHierarchy.AllTexts.Add(this);
        }
        public Text(Vector2 recposition, Vector2 scale, string text, Font font)
        {
            RecPosition = recposition;
            Scale = scale;
            this.text = text;
            this.font = font;
            SceneManager.LoadedScene.SceneHierarchy.AllTexts.Add(this);
        }
        public Text(Vector2 recposition, Vector2 scale, string text)
        {
            RecPosition = recposition;
            Scale = scale;
            this.text = text;
            SceneManager.LoadedScene.SceneHierarchy.AllTexts.Add(this);
        }
        public Text(Vector2 recposition,string text)
        {
            RecPosition = recposition;
            this.text = text;
            SceneManager.LoadedScene.SceneHierarchy.AllTexts.Add(this);
        }

        public void DestroySelf()
        {
            SceneManager.LoadedScene.SceneHierarchy.AllTexts.Remove(this);
        }
    }
}

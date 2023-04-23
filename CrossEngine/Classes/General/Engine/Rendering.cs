using CrossEngine.Classes;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CrossEngine.Shapes;
using CrossEngine.UI;

namespace CrossEngine
{
    public class Rendering
    {
        public static Graphics WorldGraf;
        public static Graphics UIGraf;

        public static Vector2 CameraMove = Vector2.zero;

        static List<GameObject> GameObjects = new List<GameObject>();
        static Bitmap bmp;

        public static void RenderStart(object sender, PaintEventArgs e)
        {
            CleanGraphics(e.Graphics);
            Camera.Refresh();
            RenderGameObjects();
            //RenderShapes();
            //RenderUiElements();
            Window.mainForm.UIpic.Image = bmp;
            //Window.mainForm.UIpic.Size = new Size(Window.Panel.Size.Width, Window.Panel.Size.Height);
        }

        static void CleanGraphics(Graphics graph)
        {
            WorldGraf = graph;
            WorldGraf.Clear(Camera.BGcolore);

            bmp = new Bitmap(Window.Panel.Size.Width, Window.Panel.Size.Height);
            UIGraf = Graphics.FromImage(bmp);
            UIGraf.Clear(Color.Transparent);
        }
        static void RenderGameObjects()
        {
            if (SceneManager.LoadedScene.SceneHierarchy.AllGameObjects.Count > 0)
            {
                OderGameObjects();

                for (int i = 0; i < GameObjects.Count; i++)
                {
                    if (GameObjects[i].SpriteRendere != null)
                    {
                        RenderGameObject
                        (GameObjects[i].SpriteRendere.image, GameObjects[i].Position
                        , GameObjects[i].SpriteRendere.SpriteSize, GameObjects[i].Rotation);

                        GameObjects[i].UpdateComponents();
                    }
                }
            }
        }
        static void RenderGameObject(Image image, Vector2 Position, Vector2 Scale, float Rotation)
        {
            Position = WorldSpace.ConvertMeterToPixelUnit(Position);

            if (image != null)
            {
                if (Rotation != 0)
                {
                    image = RotateSprite(new Bitmap(image), -Rotation);
                }
                WorldGraf.DrawImage(image, Position.x - (Scale.x / 2), -Position.y - (Scale.y / 2), Scale.x, Scale.y);
            }
        }
        static void RenderLines()
        {
            if (SceneManager.LoadedScene.SceneHierarchy.AllLine.Count > 0)
            {
                foreach (Line line in SceneManager.LoadedScene.SceneHierarchy.AllLine)
                {
                    if (line != null)
                    {
                        RenderLine(line.color, line.Position1, line.Position2);
                    }
                }

                SceneManager.LoadedScene.SceneHierarchy.AllLine.Clear();
            }
        }
        static void RenderLine(Color color, Vector2 Position1, Vector2 Position2)
        {
            Position1 = WorldSpace.ConvertMeterToPixelUnit(Position1);
            Position2 = WorldSpace.ConvertMeterToPixelUnit(Position2);
            
            Pen p = new Pen(color, 1);
            WorldGraf.DrawLine(p, Position1.x, -Position1.y, Position2.x, -Position2.y);
        }
        static void RenderCycles()
        {
            if (SceneManager.LoadedScene.SceneHierarchy.AllCycles.Count > 0)
            {
                foreach (Cycle cycle in SceneManager.LoadedScene.SceneHierarchy.AllCycles)
                {
                    if (cycle != null)
                    {
                        RenderCycle(cycle.color, cycle.Position, cycle.Radias);
                    }
                }

                SceneManager.LoadedScene.SceneHierarchy.AllCycles.Clear();
            }
        }
        static void RenderCycle(Color color, Vector2 Position, float Radias)
        {
            Position = WorldSpace.ConvertMeterToPixelUnit(Position);
            Radias = WorldSpace.ConvertMeterToPixelUnit(Radias);

            Position = new Vector2(Position.x - (Radias / 2), -Position.y - (Radias / 2));

            Pen p = new Pen(color);
            Brush brush = p.Brush;

            WorldGraf.FillEllipse(brush, Position.x, Position.y, Radias, Radias);
        }
        static void RenderUiElements()
        {
            RenderUiTexts();
        }
        static void RenderUiTexts()
        {
            if (SceneManager.LoadedScene.SceneHierarchy.AllTexts.Count > 0)
            {
                for (int i = 0; i < SceneManager.LoadedScene.SceneHierarchy.AllTexts.Count; i++)
                {
                    Text te = SceneManager.LoadedScene.SceneHierarchy.AllTexts[i];

                    if (te != null)
                    {
                        RenderText(te);
                    }
                }
            }
        }
        static void RenderText(Text text)
        {
            Pen pe = new Pen(text.color, text.size);
            Brush bru = pe.Brush;
            Font fo = new Font("", text.size, text.fontstyle, GraphicsUnit.Pixel);
            float x = (Camera.Position.x + text.RecPosition.x);
            float y = (Camera.Position.y + text.RecPosition.y);
            Vector2 pos = new Vector2(x, y);
            pos = WorldSpace.ConvertMeterToPixelUnit(pos);

            UIGraf.DrawString(text.text, fo, bru, 0, 0);
        }
        static void RenderShapes()
        {
            RenderLines();
            RenderCycles();
        }
        static void OderGameObjects()
        {
            GameObjects = SceneManager.LoadedScene.SceneHierarchy.AllGameObjects;
            uint count = (uint)GameObjects.Count;

            for (uint i = 0; i < count; i++)
            {
                if (GameObjects[(int)i].SpriteRendere != null)
                {
                    for (uint j = i; j < count; j++)
                    {
                        if (GameObjects[(int)j].SpriteRendere != null)
                        {
                            int Oder1 = GameObjects[(int)j].SpriteRendere.OderLayer;
                            int Oder2 = GameObjects[(int)i].SpriteRendere.OderLayer;

                            if (Oder1 > Oder2)
                            {
                                GameObject newGO = GameObjects[(int)i];

                                GameObjects[(int)i] = GameObjects[(int)j];
                                GameObjects[(int)j] = newGO;
                            }
                        }
                    }
                }
            }
        }

        static Bitmap RotateSprite(Bitmap bmp, float angle)
        {
            Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
            rotatedImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Set the rotation point to the center in the matrix
                g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                // Rotate
                g.RotateTransform(angle);
                // Restore rotation point in the matrix
                g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                // Draw the image on the bitmap
                g.DrawImage(bmp, new Point(0, 0));
            }

            return rotatedImage;
        }
    }
}

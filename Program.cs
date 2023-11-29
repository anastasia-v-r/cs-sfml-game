namespace cs_sfml_game
{
    using SFML;
    using SFML.Graphics;
    using SFML.System;
    using SFML.Window;
    using System.Numerics;

    internal class Program
    {
        static Color RandomColor()
        {
            List<Color> colors = new List<Color>
            {
                Color.White,
                Color.Black,
                Color.Red,
                new Color(255, 165, 0),
                Color.Yellow,
                Color.Green,
                Color.Blue,
                new Color(75, 0, 130),
                new Color(143, 0, 255)
            };

            return colors[new Random().Next(colors.Count)];
        }

        static void Main(string[] args)
        {
            VideoMode screenRes = new VideoMode(1920, 1080);

            List<RectangleShape> shapes = new List<RectangleShape>();
            int subdivisions_x = 120;
            int subdivisions_y = 180;
            for (int i = 0; i < subdivisions_x; i++)
            {
                for (int j = 0; j < subdivisions_y; j++)
                {
                    RectangleShape temp = new RectangleShape(new Vector2f(screenRes.Width / subdivisions_x, screenRes.Height / subdivisions_y));
                    temp.FillColor = RandomColor();
                    temp.Position = new Vector2f(i * temp.Size.X, j * temp.Size.Y);
                    shapes.Add(temp);
                }
            }

            RenderWindow window = new RenderWindow(screenRes, "Game!");
            window.Closed += (sender, args) => { ((RenderWindow)sender).Close(); return; };
            window.KeyPressed += (sender, args) => {
                switch (args.Code)
                {
                    case Keyboard.Key.Escape:
                        ((RenderWindow)sender).Close();
                        break;
                    case Keyboard.Key.Space:
                        foreach (var shape in shapes)
                            shape.FillColor = RandomColor();
                        break;
                    default: break;
                }
            };

            while (window.IsOpen)
            {
                window.DispatchEvents();

                // some logic

                window.Clear(Color.White);
                foreach (var shape in shapes)
                {
                    window.Draw(shape);
                }
                window.Display();
            }
        }
    }
}

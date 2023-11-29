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
            List<RectangleShape> shapes = new List<RectangleShape>();
            for (int i = 0; i < 38; i++)
            {
                for (int j = 0; j < 21; j++)
                {
                    RectangleShape temp = new RectangleShape(new Vector2f(50, 50));
                    temp.FillColor = RandomColor();
                    temp.Position = new Vector2f(i * 50, j * 50);
                    shapes.Add(temp);
                }
            }

            RenderWindow window = new RenderWindow(new VideoMode(1920, 1080), "Game!");
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

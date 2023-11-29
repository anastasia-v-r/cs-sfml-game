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
            List<RectangleShape> shapes = [
                new RectangleShape(new Vector2f(100, 100)),
                new RectangleShape(new Vector2f(100, 100)),
                new RectangleShape(new Vector2f(100, 100))
            ];

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

            
            shapes[0].FillColor = Color.Black;
            shapes[0].Position = new Vector2f(100, 100);
            shapes[1].FillColor = Color.Blue;
            shapes[1].Position = new Vector2f(200, 200);
            shapes[2].FillColor = Color.Red;
            shapes[2].Position = new Vector2f(300, 300);


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

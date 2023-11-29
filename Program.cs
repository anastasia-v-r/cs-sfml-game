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
            Console.WriteLine("Hello, World!");
        }
    }
}

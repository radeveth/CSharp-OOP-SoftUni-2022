using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public interface IDrawable
    {
        public void Draw();
    }

    public class Circle : IDrawable
    {
        const char SYMBOL = '*';

        private int radius;

        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public int Radius 
        {
            get { return this.radius; }
            set { this.radius = value; }
        }

        public void Draw()
        {
            double t = 0.4;
            double rIn = radius - t, rOut = radius + t;
            for (double y = radius; y >= - radius; --y)
            {
                for (double x = - radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write(SYMBOL);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    public class Rectangle : IDrawable
    {
        const char SYMBOL = '*';

        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }
        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public void Draw()
        {
            for (int i = 1; i <= width; i++)
            {
                for (int j = 1; j <= height; j++)
                {
                    if (j == 1 || j == height || i == 1 || i == width)
                    {
                        Console.Write(SYMBOL);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    internal class Rectangle : Shape
    {
        private double height;
        private double width;


        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }


        public double Height 
        { 
            get => this.height; 
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zaro or smaller than zero!");
                }
                this.height = value;
            }
        }
        public double Width 
        { 
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zaro or smaller than zero!");
                }
                this.width = value;
            }
        }


        public override double CalculateArea(double a)
        {
            return a * a;
        }

        public override double CalculatePerimeter(double a)
        {
            return 2 * a;
        }

        public override void Draw()
        {
            for (int i = 1; i <= width; i++)
            {
                for (int j = 1; j <= height; j++)
                {
                    if (j == 1 || j == height || i == 1 || i == width)
                    {
                        Console.Write("*");
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

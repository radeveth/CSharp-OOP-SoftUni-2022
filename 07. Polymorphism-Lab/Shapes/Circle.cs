using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    internal class Circle : Shape
    {
        private double radius;


        public Circle(double radius)
        {
            this.Radius = radius;
        }


        public double Radius 
        { 
            get => this.radius;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius cannot be zaro or smaller than zero!");
                }
                this.radius = value;
            }
        }


        public override double CalculateArea(double a)
        {
            return Math.PI * a * a;
        }

        public override double CalculatePerimeter(double a)
        {
            return 2 * Math.PI * a;
        }

        public override void Draw()
        {
            double t = 0.4;
            double rIn = radius - t, rOut = radius + t;
            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    internal abstract class Shape
    {
        public abstract double CalculatePerimeter(double a);
        public abstract double CalculateArea(double a);
        public abstract void Draw();
    }
}

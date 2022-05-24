using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Box_Data
{
    internal class Box : IBox
    {
        private double length;
        private double width;
        private double height;


        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }


        public double Length 
        {
            get => this.length;
            set 
            {
                if (value <= 0)
                {
                    string text = "Length";
                    throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidInput, text));
                }

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            set
            {
                if (value <= 0)
                {
                    string text = "Width";
                    throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidInput, text));
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            set
            {
                if (value <= 0)
                {
                    string text = "Height";
                    throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidInput, text));
                }

                this.height = value;
            }
        }

        public string LateralSurfaceArea()
        {
            double result = (2 * (this.Length * this.Height)) + (2 * (this.Width * this.Height));
            return $"Lateral Surface Area - {result:f2}";
        }

        public string SurfaceArea()
        {
            double result = 
                (2 * (this.Length * this.Width)) + 
                (2 * (this.Length * this.Height)) +
                (2 * (this.Width * this.Height));
            return $"Surface Area - {result:f2}";
        }

        public string Volume()
        {
            double result = this.Height * this.Width * this.Length;
            return $"Volume - {result:f2}";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(SurfaceArea());
            sb.AppendLine(LateralSurfaceArea());
            sb.AppendLine(Volume());
            
            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public string Start();
        public string Stop();
    }

    public interface IElectricCar
    {
        public int Batery { get; set; }
    }

    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; set; }
        public string Color { get; set; }

        public string Start()
        {
            throw new NotImplementedException();
        }

        public string Stop()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{this.Color} Seat {this.Model}";
        }
    }

    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int batery)
        {
            this.Model = model;
            this.Color = color;
            this.Batery = batery;
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public int Batery { get; set; }

        public string Start()
        {
            throw new NotImplementedException();
        }

        public string Stop()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{this.Color} Tesla {this.Model} with {this.Batery} Batteries";
        }
    }
}

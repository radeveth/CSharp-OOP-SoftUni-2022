using System;
using System.Text;
using System.Collections.Generic;
using CarRacing.Utilities.Messages;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System.Linq;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;
        public IReadOnlyCollection<ICar> Models => this.cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }


        public void Add(ICar model)
        {
            if (model== null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            this.cars.Add(model);
        }

        public ICar FindBy(string vin)
        {
            return this.cars.FirstOrDefault(x => x.VIN == vin);
        }

        public bool Remove(ICar car)
        {
            return this.cars.Remove(car);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo_P01_and_P02
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public string Name 
        { 
            get => this.name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace.");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get => this.age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be smaller than zero.");
                }
                this.age = value;
            }
        }

        public string Id
        {
            get => this.id;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Id cannot be null or whitespace.");
                }
                this.id = value;
            }
        }

        public string Birthdate
        {
            get => this.birthdate;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Birthday property cannot be null or whitespace.");
                }
                this.birthdate = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}\n{this.Age}";
        }
    }
}

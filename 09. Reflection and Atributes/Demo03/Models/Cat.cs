using Demo03.Attributes;

namespace Demo03.Models
{
    [Author("Rado", Description = "class Cat that inherit class Animal")]
    public class Cat : Animal
    {
        public Cat()
        {
        }

        public Cat(string name, int age) 
            : base(name, age)
        {
        }

        public Cat(string name, int age, string sound, int energy) 
            : base(name, age, sound, energy)
        {
        }
    }
}

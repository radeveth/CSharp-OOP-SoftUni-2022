namespace Demo03.Models
{
    public class Dog : Animal
    {
        public Dog()
        {
        }

        public Dog(string name, int age) 
            : base(name, age)
        {
        }

        public Dog(string name, int age, string sound, int energy) 
            : base(name, age, sound, energy)
        {
        }
    }
}

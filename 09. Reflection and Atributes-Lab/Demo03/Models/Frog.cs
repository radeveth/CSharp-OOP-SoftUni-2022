namespace Demo03.Models
{
    public class Frog : Animal
    {
        public Frog()
        {
        }

        public Frog(string name, int age) 
            : base(name, age)
        {
        }

        public Frog(string name, int age, string sound, int energy) 
            : base(name, age, sound, energy)
        {
        }
    }
}

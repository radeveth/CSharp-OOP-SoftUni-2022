namespace Demo03
{
    public interface IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sound { get; set; }
        public int Energy { get; set; }
        public string Eat(string food);
        public string ProduceSoud();
        public bool IsHaveEnergy();

    }
}

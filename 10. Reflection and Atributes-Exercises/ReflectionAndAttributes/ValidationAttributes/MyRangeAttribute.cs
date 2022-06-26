namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public int MinValue 
        { 
            get => this.minValue; 
            set => this.minValue = value; 
        }
        public int MaxValue
        {
            get => this.maxValue;
            set => this.maxValue = value;
        }

        public override bool IsValid(object obj) => (int)obj >= this.MinValue && (int)obj <= this.MaxValue;
    }
}

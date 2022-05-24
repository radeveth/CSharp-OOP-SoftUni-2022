namespace Class_Box_Data
{
    internal interface IBox
    {
        public double Length { get; }
        public double Width { get; }
        public double Height { get; }

        public string SurfaceArea();
        public string LateralSurfaceArea();
        public string Volume();
    }
}

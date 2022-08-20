namespace Formula1
{
    using Formula1.Core;
    using Formula1.Core.Contracts;
    public class StartUp
    {
        public static void Main()
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}

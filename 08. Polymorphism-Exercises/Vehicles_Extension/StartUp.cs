using System;
using Vehicles_Extension.Core;

namespace Vehicles_Extension
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}

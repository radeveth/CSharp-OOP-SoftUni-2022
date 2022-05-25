using Vehicles_Extension.Models;

namespace Vehicles_Extension.Core
{
    internal interface IEngine
    {
        public void Run();
        public Vehicle Input(); 
    }
}

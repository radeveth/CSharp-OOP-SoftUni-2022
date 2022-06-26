using System;
using System.Reflection;

namespace Tracker_Task
{
    public class Tracker
    {
        public void PrintMethodsByAuthor(string name)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                foreach (var method in type.GetMethods())
                {
                    var attribute = method.GetCustomAttribute<AuthorAttribute>();

                    if (attribute != null && attribute.Name == name)
                    {
                        Console.WriteLine(method.Name);
                    }
                }
            }
        }
    }
}

using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var spy = new Spy();
            Console.WriteLine(spy.StealFieldInfo("Hacker", new string[] { "username", "password" }));
            Console.WriteLine(spy.AnalyzeAccessModifiers("Hacker"));
            Console.WriteLine(spy.RevealPrivateMethods("Hacker"));
            Console.WriteLine(spy.CollectGettersAndSetters("Hacker"));
        }
    }
}

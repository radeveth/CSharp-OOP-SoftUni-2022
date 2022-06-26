using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, string[] fields)
        {
            StringBuilder sb = new StringBuilder();

            var baseType = "Stealer";
            var type = Type.GetType($"{baseType}.{className}");

            //Console.Write("Enter username: ");
            //string username = Console.ReadLine();
            //Console.Write("Enter password: ");
            //string password = Console.ReadLine();

            //Object classInstance = Activator.CreateInstance(type, username, password);
            Object classInstance = Activator.CreateInstance(type);

            var allFields = type.GetFields
                (BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);

            Console.WriteLine($"Class under investigation: {type}");
            foreach (var field in allFields.Where(x => fields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name}: {field.GetValue(classInstance)}");
            }

            return sb.ToString();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            var baseClass = "Stealer";
            var type = Type.GetType($"{baseClass}.{className}");

            Object classInstance = Activator.CreateInstance(type);

            var methods = type.GetMethods
                (BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);

            var fields = type.GetFields
                (BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance);

            foreach (var field in fields)
            {
                if (field.IsPublic)
                {
                    sb.AppendLine($"{field.Name} have to be private!");
                }
            }

            foreach (var method in methods)
            {
                if (method.IsPublic && method.Name.ToString().StartsWith("set"))
                {
                    sb.AppendLine($"{method.Name} have to be private!");
                }
                if (method.IsPrivate && method.Name.ToString().StartsWith("get"))
                {
                    sb.AppendLine($"{method.Name} have to be public!");
                }
            }

            return sb.ToString();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            var baseClass = "Stealer";
            var type = Type.GetType($"{baseClass}.{className}");

            Object classInstance = Activator.CreateInstance(type);

            var privatMethods = type.GetMethods
                (BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.IsPrivate);

            sb.AppendLine($"All private Methods of {type}");
            sb.AppendLine($"Base class: {type.BaseType.Name}");
            foreach (var privateMethod in privatMethods)
            {
                sb.AppendLine(privateMethod.Name);
            }

            return sb.ToString();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();

            var baseType = "Stealer";
            var type = Type.GetType($"{baseType}.{className}");

            Object classInstance = Activator.CreateInstance(type);

            var allGetters = type.GetMethods
                (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .Where(x => x.Name.StartsWith("get"));

            var allStetters = type.GetMethods
               (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
               .Where(x => x.Name.StartsWith("set"));

            foreach (var getMethod in allGetters)
            {
                sb.AppendLine($"{getMethod.Name} will return {getMethod.ReturnType}");
            }
            foreach (var setMethod in allStetters)
            {
                sb.AppendLine($"{setMethod.Name} will set field of {string.Join(" ", setMethod.GetParameters().First().ParameterType)}");
                // {string.Join(" ", setMethod.GetParameters().ToList())}
            }

            return sb.ToString();
        }
    }
}
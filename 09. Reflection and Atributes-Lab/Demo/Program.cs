using System;
using System.Linq;
using System.Reflection;

namespace Demo
{
    public class Program
    {
        public class Person
        {
            private string id;

            public Person()
            {

            }

            public Person(string firstName, string lastName)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
            }


            public string FirstName { get; set; }
            public string LastName { get; set; }

            public void Eat(string food)
            {
                Console.WriteLine($"Eating {food}...");
            }
            public void Walk()
            {
                Console.WriteLine($"Walking...");
            }
            public void Talk()
            {
                Console.WriteLine("Talking...");
            }
        }

        static void Main(string[] args)
        {
            Assembly currExecutable = Assembly.GetExecutingAssembly();
            Console.WriteLine($"Types int {currExecutable.GetName().Name}: {currExecutable.GetTypes().Count()}");
            foreach (var item in currExecutable.GetTypes())
            {
                Console.WriteLine(item);
            }


            Console.WriteLine(new string('-', 80));


            Person person = new Person("Pater", "Ivanov");

            // typeof - type
            // GetType - instance
            // Type.GetType

            Type type1 = typeof(Person); // Person.Program+Person
            Type type2 = Type.GetType("Demo.Program+Person"); // Person.Program+Person
            Type type3 = person.GetType(); // Person.Program+Person


            Console.WriteLine(typeof(Person)); // Demo.Program+Person
            Console.WriteLine(person.GetType().Name); // Person
            Console.WriteLine(person.GetType().FullName); // Person.Program+Person
            Console.WriteLine(person.GetType().BaseType); // System.Object

            Console.WriteLine(new string('-', 80));

            var methods = person.GetType().GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);

                if (method.Name == "Talk")
                {
                    method.Invoke(person, null);
                }
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 80));
            Console.WriteLine();

            var person2 = Activator.CreateInstance(type3) as Person;
            var person3 = Activator.CreateInstance(type3, "Gosho", "Georgiev") as Person;
            person3.Eat("Eggs");

            Console.WriteLine(new string('-', 80));
            var fields = type3.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var allFields = type3.GetFields
                (BindingFlags.NonPublic | BindingFlags.Instance | 
                BindingFlags.Public | BindingFlags.Static);

            foreach (var f in fields)
            {
                Console.WriteLine(f.Name);
                Console.WriteLine(f.FieldType);
                Console.WriteLine();
            }

            Console.WriteLine();
            var field = type3.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(field.FieldType);
            field.SetValue(person2, "CHANGED!");

            Console.WriteLine(new String('-', 80));

            var constructors = type3.GetConstructors();
            foreach (var ctor in constructors)
            {
                Console.WriteLine(ctor.GetType().Name);
                Console.WriteLine(ctor.GetParameters());
                foreach (var ctorParameters in ctor.GetParameters())
                {
                    Console.WriteLine(ctorParameters);
                }

                Console.WriteLine();
            }

            // methods - returnType...
        }
    }
}
